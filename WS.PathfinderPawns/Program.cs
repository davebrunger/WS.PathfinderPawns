var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

var command = new RootCommand("Application to generate a PDF file containing Pathfinder pawns");

var imageFileOption = new Option<FileInfo>("--image-file", "Path to image file");
imageFileOption.AddAlias("-i");
imageFileOption.IsRequired = true;
imageFileOption.AddValidator(result =>
{
    if (!File.Exists(result.GetValueForOption(imageFileOption)!.FullName))
    {
        result.ErrorMessage = $"Image file '{result.GetValueForOption(imageFileOption)}' does not exist.";
        return;
    }
    try
    {
        using var image = XImage.FromFile(result.GetValueForOption(imageFileOption)!.FullName);
    }
    catch (InvalidOperationException)
    {
        result.ErrorMessage = $"Image file '{result.GetValueForOption(imageFileOption)}' is not a valid image file (BMP, PNG, GIF, JPEG, TIFF or PDF).";
    }
});

var outputFileOption = new Option<FileInfo>("--output-file", () => new FileInfo(Path.Join(documentsFolder, "Pawns.pdf")),"Path to output file");
outputFileOption.AddAlias("-o");

var paperSizeOption = new Option<PageSize>("--page-size", () => PageSize.A4, "Size of output paper");
paperSizeOption.AddAlias("-p");

var pawnSizeOption = new Option<PawnSize>("--pawn-size", () => PawnSize.Medium, "Size of pawns to generate");
pawnSizeOption.AddAlias("-s");

command.AddOption(imageFileOption);
command.AddOption(outputFileOption);
command.AddOption(paperSizeOption);
command.AddOption(pawnSizeOption);

command.SetHandler(PawnPdfDrawer.DrawPawnPdf, imageFileOption, outputFileOption, paperSizeOption, pawnSizeOption);

return await command.InvokeAsync(args);
