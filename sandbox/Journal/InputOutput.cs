/*
 * Copyright (c) 2024 Brother Keers, Brigham Young University Idaho
 */

public class InputOutput {

    // Storage directory for journal files
    private string storage;

    // Constructor for the InputOutput class
    public InputOutput(string storageDir) {
        storage = storageDir;
        // Ensure the storage directory exists
        EnsureDirExists();
    }

    // Method to ensure the storage directory exists
    private void EnsureDirExists() {
        // Check if the storage path is not null or empty
        if (!string.IsNullOrEmpty(storage)) {
            try {
                // Check if the directory exists, and create it if not
                if (!Directory.Exists(storage)) {
                    Directory.CreateDirectory(storage);
                    Console.WriteLine($"Directory '{storage}' created successfully.");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        } else {
            Console.WriteLine("Storage path is null or empty. Please provide a valid path.");
        }
    }

    // Method to get a list of journal filenames in the storage directory
    public List<string> GetJournals() {
        List<string> filenames = new List<string>();

        DirectoryInfo directory = new DirectoryInfo(storage);
        FileInfo[] files = directory.GetFiles();

        foreach (FileInfo file in files) {
            filenames.Add(file.Name);
        }

        return filenames;
    }

    // Method to load content from a file
    public string[] LoadFile(string filename) {
        string fileToLoad = Path.Combine(storage, filename);

        // Check if the specified file exists
        if (!File.Exists(fileToLoad)) {
            Console.WriteLine("Specified file does not exist!");
            return Array.Empty<string>();
        }

        // Read all lines from the file and return as an array
        string[] lines = File.ReadAllLines(fileToLoad);
        return lines;
    }

    // Method to write content to a file
    public void WriteFile(string filename, List<string> content) {
        string fileToWrite = Path.Combine(storage, filename);

        try {
            // Write all lines to the specified file
            File.WriteAllLines(fileToWrite, content);
            Console.WriteLine($"File '{fileToWrite}' written successfully.");
        } catch (Exception ex) {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
}
