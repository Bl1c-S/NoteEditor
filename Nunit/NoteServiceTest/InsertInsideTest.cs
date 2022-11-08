namespace Nunit.NoteServiceTest;

[TestClass]
public class InsertInsideTest
{
     [TestMethod]
     public void Test_WhenReadFirstNote1str()
     {
          string changedNote = "chnote";
          int lineIndex = 0;

          string[] text = new string[] { "1str", "+2str","3str", "[1date", "+4str", "[2date", "5str" };
          NoteLogic noteLogic = new(text, lineIndex);

          string[] executeText = new string[] { changedNote, "+2str", "3str", "[1date", "+4str", "[2date", "5str" };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
               Assert.AreEqual(executeText[i], actualText[i]);
     }
     [TestMethod]
     public void Test_WhenReadFirstNoteAttribute3str()
     {
          string changedNote = "chnote";
          int lineIndex = 0;

          string[] text = new string[] { "+1str", "2str", "3str", "[1date", "+4str", "[2date", "5str" };
          NoteLogic noteLogic = new(text, lineIndex);

          string[] executeText = new string[] { '+' + changedNote, "[1date", "+4str", "[2date", "5str" };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
               Assert.AreEqual(executeText[i], actualText[i]);
     }
     [TestMethod]
     public void Test_WhenReadInsideNoteAttribute1str()
     {
          string changedNote = "chnote";
          int lineIndex = 4;

          string[] text = new string[] { "1str", "+2str", "-3str", "[1date", "+4str", "[2date", "5str" };
          NoteLogic noteLogic = new(text, lineIndex);

          string[] executeText = new string[] { "1str", "+2str", "-3str", "[1date", '+' + changedNote, "[2date", "5str" };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
               Assert.AreEqual(executeText[i], actualText[i]);
     }
     [TestMethod]
     public void Test_WhenReadInsideNote2str()
     {
          string changedNote = "chnote";
          int lineIndex = 1;

          string[] text = new string[] { "1str", "+2str", "3str", "[1date", "+4str", "[2date", "5str" };
          NoteLogic noteLogic = new(text, lineIndex);

          string[] executeText = new string[] { "1str", '+' + changedNote, "[1date", "+4str", "[2date", "5str" };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
               Assert.AreEqual(executeText[i], actualText[i]);
     }
     [TestMethod]
     public void Test_Should_WhenReadEndNoteAttribute1str()
     {
          string changedNote = "chnote";
          int lineIndex = 6;

          string[] text = new string[] { "1str", "+2str", "3str", "[1date", "+4str", "[2date", "-5str" };
          NoteLogic noteLogic = new(text, lineIndex);

          string[] executeText = new string[] { "1str", "+2str", "3str", "[1date", "+4str", "[2date", '-' + changedNote };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
               Assert.AreEqual(executeText[i], actualText[i]);
     }
     [TestMethod]
     public void Test_Should_WhenReadEndNote2str()
     {
          string changedNote = "chnote";
          int lineIndex = 6;

          string[] text = new string[] { "1str", "+2str", "3str", "[1date", "+4str", "[2date", "5str", "6str" };
          NoteLogic noteLogic = new(text, lineIndex);

          string[] executeText = new string[] { "1str", "+2str", "3str", "[1date", "+4str", "[2date", changedNote };

          string[] actualText = noteLogic.InsertInside(changedNote);

          for (var i = 0; i < executeText.Length; i++)
               Assert.AreEqual(executeText[i], actualText[i]);
     }
}