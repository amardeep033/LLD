//Composite pattern is used to treat individual objects and compositions of objects uniformly. 
//It allows you to compose objects into tree structures and work with these structures as if they were individual objects.
// The important thing is NOT: “Can it contain itself?”
// The important thing is: “Can client code treat single objects and collections the same way?”

Console.WriteLine("-------------Before applying composite pattern----------------");

BadFile bad_file1 = new BadFile("resume.pdf");
BadFile bad_file2 = new BadFile("photo.png");

BadFolder bad_folder = new BadFolder("Documents");

bad_folder.AddFile(bad_file1);
bad_folder.AddFile(bad_file2);

bad_folder.Show();

Console.WriteLine("-------------After applying composite pattern----------------");

File file1 = new File("resume.pdf");
File file2 = new File("photo.png");
File file3 = new File("notes.txt");

Folder images = new Folder("Images");
images.Add(file2);

Folder documents = new Folder("Documents");

documents.Add(file1);
documents.Add(file3);
documents.Add(images);

documents.Show();