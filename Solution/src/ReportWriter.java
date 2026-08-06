import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.NavigableSet;
import java.util.TreeSet;

import models.SalesPerChannel;
import models.Transfer;
import utils.ResponseStucture;

public class ReportWriter {
	
	private HashMap<Integer, Transfer> transfers = new HashMap<Integer, Transfer>();
	private ArrayList<String> divergences = new ArrayList<String>();
	private SalesPerChannel salesPerChannel = new SalesPerChannel();
	private BufferedWriter writer;
	
	public ReportWriter(HashMap<Integer, Transfer> transfers, ArrayList<String> divergences,
			SalesPerChannel salesPerChannel) {
		this.transfers = transfers;
		this.divergences = divergences;
		this.salesPerChannel = salesPerChannel;
	}
	
	public void register() throws IOException {
		registerTransfers();
		registerDivergences();
		registerSalesPerChannel();
	}
	
	private void registerTransfers() throws IOException {
		writer = Files.newBufferedWriter(
				Paths.get("outputs/transfere.txt"), StandardCharsets.UTF_16);
		
		writer.write(ResponseStucture.TRANSFER_HEADER);
		
		NavigableSet<Integer> keys = new TreeSet<Integer>(transfers.keySet());
		
		for(int key: keys) {
			Transfer transfer = transfers.get(key);
			
			writer.write(transfer.toString());
		}
		
		writer.flush();
		writer.close();
	}
	
	private void registerDivergences() throws IOException {
		writer = Files.newBufferedWriter(
				Paths.get("outputs/divergencias.txt"), StandardCharsets.UTF_16);
		
		for(String line: divergences) {
			writer.write(line);
		}
		
		writer.flush();
		writer.close();
	}
	
	private void registerSalesPerChannel() throws IOException {
		writer = Files.newBufferedWriter(
				Paths.get("outputs/totcanal.txt"), StandardCharsets.UTF_16);
		
		writer.write(salesPerChannel.toString());
		writer.flush();
		writer.close();
	}
	
}
