using NoteEditorDomain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit
{
    [TestClass]
    public class NoteLogicTests
    {
        [TestMethod]
        public void IsNewText_Should_When()
        {
            string line = "+1";

            NoteLogic noteLogic = new NoteLogic();
            bool isOk = noteLogic.IsNewText(line);

            Assert.IsTrue(isOk);
        }
        [TestMethod]
        public void IsNewText_ShouldFalse_WhenEmpty()
        {
            string line = string.Empty;

            NoteLogic noteLogic = new NoteLogic();
            bool isOk = noteLogic.IsNewText(line);

            Assert.IsFalse(isOk);
        }
        [TestMethod]
        public void IsNewText_ShouldFalse_WhenNoSing()
        {
            string line = "1kl";

            NoteLogic noteLogic = new NoteLogic();
            bool isOk = noteLogic.IsNewText(line);

            Assert.IsFalse(isOk);
        }
        [TestMethod]
        public void IsNewText_ShouldTrue_WhenSq()
        {
            string line = "[dsdfs\n";

            NoteLogic noteLogic = new NoteLogic();
            bool isOk = noteLogic.IsNewText(line);

            Assert.IsTrue(isOk);
        }


        [TestMethod]
        public void GetNote_ShouldNotNull_When1()
        {
            string[] text = new string[] {"+1","+2","-3"};
            int lineIndex = 1;

            NoteLogic noteLogic = new NoteLogic();
            var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);

            Assert.IsNotNull(note);
            Assert.AreEqual(2, endIndex);
        }

        [TestMethod]
        public void GetNote_ShouldExeption_WhenOutOfRange1()
        {
            string[] text = new string[] { "+1", "+2", "-3" };
            int lineIndex = 10;

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                NoteLogic noteLogic = new();
                var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);
            });
            
        }

        [TestMethod]
        public void GetNote_ShouldExeption_WhenOutOfRangeLessZero()
        {
            string[] text = new string[] { "+1", "+2", "-3" };
            int lineIndex = -1;

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                NoteLogic noteLogic = new();
                var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);
            });

        }

        [TestMethod]
        public void GetNote_ShouldExeption_WhenOutOfRangeEqualLenth()
        {
            string[] text = new string[] { "+1", "+2", "-3" };
            int lineIndex = text.Length;

            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                NoteLogic noteLogic = new();
                var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);
            });

        }

        [TestMethod]
        public void GetNote_ShouldOk_WhenOutOfRange0()
        {
            string[] text = new string[] { "+1", "+2", "-3" };
            int lineIndex = 0;

            NoteLogic noteLogic = new();
            var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);

            Assert.IsNotNull(note);
        }

        [TestMethod]
        public void GetNote_Should123_WhenVer1()
        {
            string[] text = new string[] { "123", "+2", "-3" };
            int lineIndex = 0;

            NoteLogic noteLogic = new();
            var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);

            Assert.AreEqual(1, endIndex);
            Assert.IsNotNull(note);
            Assert.AreEqual("123", note);
        }

        [TestMethod]
        public void GetNote_Should456_789_WhenVer2()
        {
            string[] text = new string[] { "123", "456", "789", "[" };
            int lineIndex = 1;

            NoteLogic noteLogic = new();
            var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);

            Assert.AreEqual(3, endIndex);
            Assert.IsNotNull(note);
            Assert.AreEqual("456\r\n789", note);
        }

        [TestMethod]
        public void GetNote_ShouldLastText_WhenLast()
        {
            string[] text = new string[] { "123", "456", "789", "LastText" };
            int lineIndex = 3;

            NoteLogic noteLogic = new();
            var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);

            Assert.AreEqual(3, endIndex);
            Assert.IsNotNull(note);
            Assert.AreEqual("LastText", note);
        }

        [TestMethod]
        public void GetNote_ShouldSingle_WhenSingle()
        {
            string[] text = new string[] { "Single" };
            int lineIndex = 0;

            NoteLogic noteLogic = new();
            var (note, endIndex) = noteLogic.GetNoteInfo(text, lineIndex);

            Assert.AreEqual(0, endIndex);
            Assert.IsNotNull(note);
            Assert.AreEqual("Single", note);
        }
    }
}
