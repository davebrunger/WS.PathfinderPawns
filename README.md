# WS.PathfinderPawns
## WS.PathfinderPawns
Application to generate a PDF file containing Pathfinder pawns

### Usage

#### Help
```
dotnet run -- -h
```

##### Output
```
Description:
  Application to generate a PDF file containing Pathfinder pawns

Usage:
  WS.PathfinderPawns [options]

Options:
  -i, --image-file <image-file>           Path to image file (Can be specified multiple times)
  (REQUIRED)                              
  -o, --output-file <output-file>         Path to output file [default: /Users/davidbrunger/Documents/Pawns.pdf]
  -p, --page-size                         Size of output paper [default: A4]
  <A0|A1|A2|A3|A4|A5|B0|B1|B2|B3|B4|B5|C
  rown|Demy|DoubleDemy|Elephant|Executiv
  e|Folio|Foolscap|GovernmentLetter|Larg
  ePost|Ledger|Legal|Letter|Medium|Post|
  QuadDemy|Quarto|RA0|RA1|RA2|RA3|RA4|RA
  5|Royal|Size10x14|Statement|STMT|Tablo
  id|Undefined>
  -s, --pawn-size                         Size of pawns to generate [default: Medium]
  <Huge|Large|Medium|Small>               
  -d, --draw-dots                         Draw coloured Dots on pawns [default: True]
  --version                               Show version information
  -?, -h, --help                          Show help and usage information
```

#### Examples
```
dotnet run -- -i \<Path to image file>
```

```
dotnet run -- -i \<Path to image file1> -i \<Path to image file1> -s Small
```

## WS.PathfinderMaps
Application to generate a multi-page PDF file containing a Pathfinder map scaled to a 1 inch grid

### Usage

#### Help
```
dotnet run -- -h
```

##### Output
```
  -i, --image-file <image-file>           Path to image file
  (REQUIRED)                              
  -o, --output-file <output-file>         Path to output file [default: /Users/davidbrunger/Documents/Map.pdf]
  -p, --page-size                         Size of output paper [default: A4]
  <A0|A1|A2|A3|A4|A5|B0|B1|B2|B3|B4|B5|C
  rown|Demy|DoubleDemy|Elephant|Executiv
  e|Folio|Foolscap|GovernmentLetter|Larg
  ePost|Ledger|Legal|Letter|Medium|Post|
  QuadDemy|Quarto|RA0|RA1|RA2|RA3|RA4|RA
  5|Royal|Size10x14|Statement|STMT|Tablo
  id|Undefined>
  -x, --image-pixels-per-inch             Pixels per inch of the image [default: 300]
  <image-pixels-per-inch>
  -m, --margin-width-inches               Width of the margin in inches [default: 0.5]
  <margin-width-inches>               
  --version                               Show version information
  -?, -h, --help                          Show help and usage information
```

#### Examples
```
dotnet run -- -i \<Path to image file>
```

```
dotnet run -- -i \<Path to image file1> -x 160
```