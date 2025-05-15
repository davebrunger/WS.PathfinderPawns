var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

var command = new RootCommand("Application to generate a multi-page PDF file containing a Pathfinder map scaled to a 1 inch grid.");

var imageFileOption = new Option<FileInfo>("--image-file", "Path to image file");
imageFileOption.AddAlias("-i");
imageFileOption.IsRequired = true;

var outputFileOption = new Option<FileInfo>("--output-file", () => new FileInfo(Path.Join(documentsFolder, "Map.pdf")),"Path to output file");
outputFileOption.AddAlias("-o");

var paperSizeOption = new Option<PageSize>("--page-size", () => PageSize.A4, "Size of output paper");
paperSizeOption.AddAlias("-p");

var imagePixelsPerInchOption = new Option<double>("--image-pixels-per-inch", () => 300, "Pixels per inch of the image");
outputFileOption.AddAlias("-x");

var marginWidthInchesOption = new Option<double>("--margin-width-inches", () => 0.5, "Width of the margin in inches");
marginWidthInchesOption.AddAlias("-m");

command.AddOption(imageFileOption);
command.AddOption(outputFileOption);
command.AddOption(paperSizeOption);
command.AddOption(imagePixelsPerInchOption);
command.AddOption(marginWidthInchesOption);

command.SetHandler(MapDrawer.DrawMapPdf, imageFileOption, outputFileOption, paperSizeOption, imagePixelsPerInchOption, marginWidthInchesOption);

return await command.InvokeAsync(args);