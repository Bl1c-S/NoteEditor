namespace Nunit.NoteServiceTest;

[TestClass]
public class InsertInsideTest
{
     [TestMethod]
     public void Test_ShouldEqual_When1()
     {
          string[] text = new string[] { "1str", "+2str\nstr2", "-3str", "3str2", "+4str" };
          int lineIndex = 0;
          NoteLogic noteLogic = new(text, lineIndex);

          string changedNote = "chnote";
          string[] executeText = new string[] { changedNote, "+2str\nstr2", "-3str", "3str2", "+4str" };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
          {
               Assert.AreEqual(executeText[i], actualText[i]);
          }
     }
     [TestMethod]
     public void Test_ShouldEqual_When2()
     {
          string[] text = new string[] { "1str", "-2str", "str2", "-3str", "3str2", "+4str" };
          int lineIndex = 1;
          NoteLogic noteLogic = new(text, lineIndex);

          string changedNote = "chnote";
          string[] executeText = new string[] { "1str", "-" + changedNote, "-3str", "3str2", "+4str" };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
          {
               Assert.AreEqual(executeText[i], actualText[i]);
          }
     }
     [TestMethod]
     public void Test_ShouldEqual_When3()
     {
          string[] text = new string[] { "1str", "+2str", "str2", "-3str", "3str2", "+4str" };
          int lineIndex = 5;
          NoteLogic noteLogic = new(text, lineIndex);

          string changedNote = "chnote";
          string[] executeText = new string[] { "1str", "+2str", "str2", "-3str", "3str2", "+" + changedNote };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
          {
               Assert.AreEqual(executeText[i], actualText[i]);
          }
     }
}