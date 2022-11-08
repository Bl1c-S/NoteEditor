namespace Nunit.NoteServiceTest;

[TestClass]
public class GetUnFormatNoteTest
{
     [TestMethod]
     public void Test_Should_1str_When1note1strAttribute ()
     {
          string[] text = new string[] { "+1str" };
          int lineIndex = 0;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "1str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, actualText);

     }
     [TestMethod]
     public void Test_Should_1str_When1note1str()
     {
          string[] text = new string[] { "1str" };
          int lineIndex = 0;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "1str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, actualText);
     }
     [TestMethod]
     public void Test_Should_2str_When1note2str()
     {
          string[] text = new string[] { "1str", "2str" };
          int lineIndex = 0;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "1str\n2str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, actualText);
     }
     [TestMethod]
     public void Test_Should_2str_When2note3str()
     {
          string[] text = new string[] { "1str", "2str", "+3str" };
          int lineIndex = 0;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "1str\n2str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, noteLogic.UF_OldNote);
     }

     [TestMethod]
     public void Test_Should_2str_When2note3strAttribute()
     {
          string[] text = new string[] { "-1str", "2str", "+3str" };
          int lineIndex = 0;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "1str\n2str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, actualText);
     }
     [TestMethod]
     public void Test_Should_1str_When3note5str()
     {
          string[] text = new string[] { "1str","-2str", "3str", "[1date", "4str" };
          int lineIndex = 2;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "3str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, actualText);
     }
     [TestMethod]
     public void Test_Should_2str_When3note5str()
     {
          string[] text = new string[] { "1str", "[1date", "3str", "4str", "+5str" };
          int lineIndex = 2;
          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "3str\n4str";

          string actualText = noteLogic.UF_OldNote;

          Assert.AreEqual(executeText, actualText);
     }


     [TestMethod]
     public void Test_ShouldExeption_WhenOutOfRange()
     {
          string[] text = new string[] { "1" };
          int lineIndex = 1;

          Assert.ThrowsException<ArgumentOutOfRangeException>(() => new NoteLogic(text, lineIndex));
     }
}