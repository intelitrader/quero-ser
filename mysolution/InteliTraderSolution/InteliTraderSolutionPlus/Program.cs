using InteliTraderSolution.Reader;
using InteliTraderSolutionPlus.ReportMaker;
using InteliTraderSolutionPlus.Writer;

var path = @"C:\Intelitrader\intelitrader\mysolution"; //write here the path to the folder that contains the files to be analized

IProductReader productReader = new ProductFileReader(path);
ISaleReader saleReader = new SaleFileReader(path);

var products = productReader.Read();
var sales = saleReader.Read();

var transferReport = ProductTransferReportMaker.Make(products, sales);
var totalChannel = TotalChannelReportMaker.Make(products, sales);
var divergency = DivergencyReportMaker.Make(products, sales);

var transferFile = new ProductTransferReportFileWriter(@$"{path}\transfere.txt", transferReport);
var totalChannelFile = new TotalChannelReportFileWriter(@$"{path}\totcanal.txt", totalChannel);
var divergencyFile = new DivergencyReportFileWriter(@$"{path}\divergencia.txt", divergency);

transferFile.Write();
totalChannelFile.Write();
divergencyFile.Write();


Console.WriteLine();
