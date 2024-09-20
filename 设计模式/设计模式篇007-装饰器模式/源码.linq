<Query Kind="Statements">
  <Namespace>System.IO.Compression</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

Stream stream = new MemoryStream(new byte[] {1,2,3,4,5});
stream = new BufferedStream(stream);
stream = new GZipStream(stream,CompressionMode.Compress,true);
stream.Dump();