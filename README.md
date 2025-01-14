# WS.PathfinderPawns
Application to generate a PDF file containing Pathfinder pawns

## Usage

### Help
```
dotnet run -- -h
```

#### Output
```
Description:
  Application to generate a PDF file containing Pathfinder pawns

Usage:
  WS.PathfinderPawns [options]

Options:
  -i, --image-file <image-file> (REQUIRED)            Path to image file
  -o, --output-file <output-file>                     Path to output file [default: 
                                                      /Users/davidbrunger/Documents/Pawns.pdf]
  -p, --page-size                                     Size of output paper [default: A4]
  <A0|A1|A2|A3|A4|A5|B0|B1|B2|B3|B4|B5|Crown|Demy|Do
  ubleDemy|Elephant|Executive|Folio|Foolscap|Governm
  entLetter|LargePost|Ledger|Legal|Letter|Medium|Pos
  t|QuadDemy|Quarto|RA0|RA1|RA2|RA3|RA4|RA5|Royal|Si
  ze10x14|Statement|STMT|Tabloid|Undefined>
  -s, --pawn-size <Huge|Large|Medium|Small>           Size of pawns to generate [default: Medium]
  --version                                           Show version information
  -?, -h, --help                                      Show help and usage information
```

### Example
```
dotnet run -- -i \<Path to image file>
```