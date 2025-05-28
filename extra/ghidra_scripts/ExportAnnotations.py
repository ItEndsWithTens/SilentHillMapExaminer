#
# Export some program annotations (namely labels, function signatures,
# and comments), along with their addresses, in a crude text format.
#
#@author Rob Martens <robert.martens@gmail.com>
#@category Export
#@runtime PyGhidra

# See https://pypi.org/project/ghidra-stubs for the origin of this snippet.
import typing
if typing.TYPE_CHECKING:
    from ghidra.ghidra_builtins import *

import enum
import os
import sys

from ghidra.program.model.symbol import SourceType, SymbolType
from ghidra.util.exception import CancelledException

from java.lang import IllegalArgumentException



class GhidraCommentStyle(enum.Enum):
    EOL = 0
    PRE = 1
    POST = 2
    PLATE = 3
    REPEATABLE = 4



try:
    outFile = askFile("Output file", "OK")
except CancelledException:
    print("Export cancelled, exiting.")
    sys.exit(0)

confirm = True
if outFile.exists():
    confirm = askYesNo("File already exists!", "Overwrite existing file?")
if confirm == False:
    print("Specified output file already exists, exiting without exporting.")
    sys.exit(0)

program = getCurrentProgram()
symbol_table = program.getSymbolTable()
symbols = symbol_table.getDefinedSymbols()
factory = program.getAddressFactory()

symbol_lists = []
for sym in symbols:
    list = [f'{sym.symbolType}', f'{sym.source}', f'{sym.address}', sym.name]
    if sym.symbolType == SymbolType.FUNCTION:
        list.append(f'{sym.object.signature}')
    symbol_lists.append(list)

comments = []
for space in factory.getAllAddressSpaces():
    set = factory.getAddressSet(space.getMinAddress(), space.getMaxAddress())

    try:
        it = program.listing.getCommentAddressIterator(set, True)
    except IllegalArgumentException:
        continue

    for address in it:
        for style in GhidraCommentStyle:
            comment = program.listing.getComment(style.value, address)
            if comment is None:
                continue
            comments.append(('Comment', f'{address}', comment, style.name))

labels = [l for l in symbol_lists if l[0] == f'{SymbolType.LABEL}']
functions = [l for l in symbol_lists if l[0] == f'{SymbolType.FUNCTION}']

analysis_s = SourceType.ANALYSIS.toString()
user_s = SourceType.USER_DEFINED.toString()

# A GUID for such a primitive format may be overkill, but it's prudent, and
# they're easy enough to generate. An existing format for this sort of data
# would have been preferable, but curiously none seem to exist.
FILE_FORMAT_GUID = '67035dec-e33b-4268-b074-f9cafc98295d'
FILE_FORMAT_VERSION = 1

with open(outFile.getAbsolutePath(), 'w') as of:
    of.write(f'FileFormatGuid {FILE_FORMAT_GUID}\n')
    of.write(f'FileFormatVersion {FILE_FORMAT_VERSION}\n\n')

    locator = getProjectRootFolder().getProjectLocator()
    name = locator.getName()
    marker = locator.getMarkerFile().toString()

    of.write(f'ProjectName {name}\n')
    of.write(f'ProjectDirectory {os.path.dirname(marker)}\n')
    of.write(f'ProgramPath {program.getDomainFile().getPathname()}\n\n')

    strings = [' '.join(item) for item in labels if item[1] == analysis_s]
    if len(strings) > 0:
        of.write('\n'.join(strings) + '\n\n\n\n')

    strings = [' '.join(item) for item in labels if item[1] == user_s]
    if len(strings) > 0:
        of.write('\n'.join(strings) + '\n\n\n\n')

    strings = [' '.join(item) for item in functions if item[1] == analysis_s]
    if len(strings) > 0:
        of.write('\n'.join(strings) + '\n\n\n\n')

    strings = [' '.join(item) for item in functions if item[1] == user_s]
    if len(strings) > 0:
        of.write('\n'.join(strings) + '\n\n\n\n')

    strings = [' '.join(item) for item in comments]
    if len(strings) > 0:
        of.write('\n\n'.join(strings) + '\n\n')
