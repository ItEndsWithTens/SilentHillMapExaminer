#
# Export some program annotations (namely labels, function signatures,
# and comments), along with their addresses, in a crude text format.
#
#@author Rob Martens <robert.martens@gmail.com>
#@category Export
#@runtime PyGhidra

from enum import Enum

from ghidra.app.util import *
from ghidra.program.model.symbol import SourceType, SymbolType
from ghidra.app.script import AskDialog

from java.lang import IllegalArgumentException



class GhidraCommentStyle(Enum):
    EOL = 0
    PRE = 1
    POST = 2
    PLATE = 3
    REPEATABLE = 4



confirm = True
outFile = askFile("Output file", "OK")
if outFile.exists():
    confirm = askYesNo("File already exists!", "Overwrite existing file?")
if confirm == False:
    raise SystemExit("Specified output file already exists, exiting without exporting.")

f_user_defined = []
l_user_defined = []
f_analysis = []
l_analysis = []

program = getCurrentProgram()
symbol_table = program.getSymbolTable()
symbols = symbol_table.getDefinedSymbols()

for sym in symbols:
    if sym.symbolType == SymbolType.LABEL:
        tuple = (sym.address.toString(), 'label', sym.name)
        if sym.source == SourceType.USER_DEFINED:
            l_user_defined.append(tuple)
        elif sym.source == SourceType.ANALYSIS:
            l_analysis.append(tuple)
    elif sym.symbolType == SymbolType.FUNCTION:
        tuple = (sym.address.toString(), 'function', sym.name, sym.object.signature.toString())
        if sym.source == SourceType.USER_DEFINED:
            f_user_defined.append(tuple)
        elif sym.source == SourceType.ANALYSIS:
            f_analysis.append(tuple)

comments = []

factory = program.getAddressFactory()

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
            comments.append((address.toString(), style.name, comment))

with open(outFile.getAbsolutePath(), 'w') as of:
    of.write('# Labels - ANALYSIS\n\n')
    for tuple in l_analysis:
        of.write(' '.join(tuple) + '\n')

    of.write('\n\n\n')

    of.write('# Functions - ANALYSIS\n\n')
    for tuple in f_analysis:
        of.write(' '.join(tuple) + '\n')

    of.write('\n\n\n')

    of.write('# Labels - USER_DEFINED\n\n')
    for tuple in l_user_defined:
        of.write(' '.join(tuple) + '\n')

    of.write('\n\n\n')

    of.write('# Functions - USER_DEFINED\n\n')
    for tuple in f_user_defined:
        of.write(' '.join(tuple) + '\n')

    of.write('\n\n\n')

    of.write('# Comments - EOL, PRE, POST, PLATE, REPEATABLE\n\n')
    for tuple in comments:
        of.write(' '.join(tuple) + '\n')
