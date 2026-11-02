using Microsoft.ML.Tokenizers;
foreach (var m in new[]{"gpt-5","gpt-4o"}) {
 try { var t = TiktokenTokenizer.CreateForModel(m); Console.WriteLine($"{m}: ok {t.CountTokens("hola mundo")}"); }
 catch (Exception e) { Console.WriteLine($"{m}: {e.GetType().Name}: {e.Message}"); }
}
