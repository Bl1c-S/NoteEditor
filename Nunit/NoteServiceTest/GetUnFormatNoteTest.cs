namespace Nunit.NoteServiceTest;

[TestClass]
public class GetUnFormatNoteTest
{
     [TestMethod]
     public void Test_ShouldOneStr_When1str()
     {
          string[] text = new string[] { "1str" };
          int lineIndex = 0;

          NoteLogic noteLogic = new(text, lineIndex);

          Assert.AreEqual("1str", noteLogic.GetUnFormatNote());

     }
     [TestMethod]
     public void Test_ShouldTwoStr_When2str()
     {
          string[] text = new string[] { "1str", "2str" };
          int lineIndex = 0;

          NoteLogic noteLogic = new(text, lineIndex);

          string executeText = "1str\n2str";

          string actualText = noteLogic.GetUnFormatNote();

          Assert.AreEqual(executeText, actualText);
     }
     [TestMethod]
     public void Test_Should1Note2str_When2note()
     {
          string[] text = new string[] { "1str", "2str", "+1str" };
          int lineIndex = 0;

          NoteLogic noteLogic = new(text, lineIndex);

          Assert.AreEqual("1str\n2str", noteLogic.GetUnFormatNote());
     }

     [TestMethod]
     public void Test_Should1Note2str_When3note()
     {
          string[] text = new string[] { "-1str", "2str", "+1str" };
          int lineIndex = 0;

          NoteLogic noteLogic = new(text, lineIndex);

          Assert.AreEqual("1str\n2str", noteLogic.GetUnFormatNote());
     }

     [TestMethod]
     public void Test_ShouldExeption_WhenOutOfRange()
     {
          string[] text = new string[] { "1" };
          int lineIndex = 1;

          Assert.ThrowsException<ArgumentOutOfRangeException>(() => new NoteLogic(text, lineIndex));
     }
}