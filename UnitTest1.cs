using ClassLibraryLab10;
using lab12_3;
namespace Test_laba12_3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            MusicalInstrument m1 = new MusicalInstrument("aaa", 12);
            MusicalInstrument m2 = new MusicalInstrument("bbb", 22);
            MusicalInstrument m3 = new MusicalInstrument("ccc", 32);
            Guitar g1 = new Guitar("abc", 5, 41);
            Piano p1 = new Piano("pp1", "Шкальная", 66, 3);
            searchTree.AddPoint(m1);
            searchTree.AddPoint(m2);
            searchTree.AddPoint(m3);
            searchTree.AddPoint(g1);
            searchTree.AddPoint(p1);
            searchTree.AddPoint(p1);
            Assert.AreEqual(searchTree.Count, 6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>();
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            Assert.AreEqual(false, searchTree.TransformToTree(tree));
        }

        [TestMethod]
        public void TestMethod3()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            Assert.AreEqual(tree.Count, searchTree.Count);
        }

        [TestMethod]
        public void TestMethod4()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(5);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            
            Assert.AreEqual(searchTree.TransformToTree(tree), true);
        }

        [TestMethod]
        public void TestMethod5()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(6);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            searchTree.DeleteTree();
            Assert.AreEqual(searchTree.Count, 0);
        }

        [TestMethod]
        public void TestMethod6()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>();
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            bool isDeleted = searchTree.DeleteTree();
            Assert.AreEqual(isDeleted, false);
        }

        [TestMethod]
        public void TestMethod7()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>();
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            MyTree<MusicalInstrument> clonedTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            clonedTree = searchTree.CloneTree(tree);
            Assert.AreEqual(clonedTree, null);
        }

        [TestMethod]
        public void TestMethod8() //два потомка
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            MusicalInstrument m = new MusicalInstrument("kkk", 13);
            searchTree.AddPoint(m);
            searchTree.AddPoint(new MusicalInstrument("jjj", 34));
            searchTree.AddPoint(new MusicalInstrument("mmm", 42));
            searchTree.AddPoint(new MusicalInstrument("aaa", 54));
            bool isDel = searchTree.RemoveItem(searchTree, m, m.Name);
            Assert.IsTrue(isDel);
        }

        [TestMethod]
        public void TestMethod9() // только правый потомок
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            MusicalInstrument m = new MusicalInstrument("aaa", 13);
            searchTree.AddPoint(m);
            searchTree.AddPoint(new MusicalInstrument("m1", 34));
            searchTree.AddPoint(new MusicalInstrument("abc2", 54));
            searchTree.AddPoint(new MusicalInstrument("zjfl", 11));
            bool isDel = searchTree.RemoveItem(searchTree, m, m.Name);
            Assert.IsTrue(isDel);
        }

        [TestMethod]
        public void TestMethod10() //только левый потомок
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            MusicalInstrument m = new MusicalInstrument("zzz", 13);
            searchTree.AddPoint(m);
            searchTree.AddPoint(new MusicalInstrument("m1", 34));
            searchTree.AddPoint(new MusicalInstrument("abc2", 54));
            searchTree.AddPoint(new MusicalInstrument("zjfl", 11));
            bool isDel = searchTree.RemoveItem(searchTree, m, m.Name);
            Assert.IsTrue(isDel);
        }

        [TestMethod]
        public void TestMethod11() 
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);
            MusicalInstrument m = new MusicalInstrument("kkk", 13);
            searchTree.AddPoint(new MusicalInstrument("jjj", 34));
            bool isDel = searchTree.RemoveItem(searchTree, m, m.Name);
            Assert.IsFalse(isDel);
        }

        [TestMethod]
        public void TestMethod12()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);

            MusicalInstrument m = new MusicalInstrument("cc", 13);
            searchTree.AddPoint(m);
            searchTree.AddPoint(new MusicalInstrument("lll", 34));
            searchTree.AddPoint(new MusicalInstrument("ddd", 54));
            searchTree.AddPoint(new MusicalInstrument("ass", 11));
            searchTree.AddPoint(new MusicalInstrument("vv", 11));
            bool isDel = searchTree.RemoveItem(searchTree, m, m.Name);
            Assert.IsTrue(isDel);
        }

        [TestMethod]
        public void TestMethod13()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);

            MusicalInstrument m = new MusicalInstrument("аа", 13);
            searchTree.AddPoint(m);
            searchTree.AddPoint(new MusicalInstrument("бб", 34));
            searchTree.AddPoint(new MusicalInstrument("вв", 54));
            searchTree.AddPoint(new MusicalInstrument("ггг", 11));
            searchTree.AddPoint(new MusicalInstrument("жжж", 11));
            Point<MusicalInstrument> item = searchTree.FindItem(searchTree,m.Name);
            Assert.AreEqual(item.Data, m);
        }

        [TestMethod]
        public void PrintEmpty()
        {
            try
            {
                MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>();
                tree.PrintTree();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Дерево пустое", ex.Message);
            }
        }

        [TestMethod]
        public void TestMethod14()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(8);
            MusicalInstrument min = tree.SearchItem();
            Random rand = new Random();
            string[] arr = { "Арфа", "Аккордион", "Баян", "Барабан" };
            int ind = rand.Next(arr.Length);
            Assert.AreEqual(min.Name, arr[ind]);
        }


        [TestMethod]
        public void TestMethod15()
        {
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(1);
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            searchTree.TransformToTree(tree);

            MusicalInstrument m = new MusicalInstrument("kkk", 13);
            searchTree.AddPoint(m);
            searchTree.AddPoint(new MusicalInstrument("jjj", 34));
            searchTree.DeleteTree();
            Point<MusicalInstrument> item = searchTree.FindItem(searchTree, m.Name);

            Assert.IsNull(item);
        }



        //Point
        [TestMethod]
        public void ConstructorWithoutParam()
        {
            Point<MusicalInstrument> p = new Point<MusicalInstrument>();
            Assert.IsNull(p.Right);
            Assert.IsNull(p.Left);
            Assert.IsNull(p.Data);
        }

        [TestMethod]
        public void CompareTo()
        {
            Point<MusicalInstrument> p1 = new Point<MusicalInstrument>(new MusicalInstrument("abc",2));
            Point<MusicalInstrument> p2 = new Point<MusicalInstrument>(new MusicalInstrument("bcd", 2));
            var res1 = p1.CompareTo(p2);
            var res2 = p2.CompareTo(p1);
            var res3 = p1.CompareTo(p1);
            Assert.AreEqual(-1, res1);
            Assert.AreEqual(1, res2);
            Assert.AreEqual(0, res3);
        }

        [TestMethod]
        public void ToStringNull()
        {
            Point<MusicalInstrument> p = new Point<MusicalInstrument>();
            var res1 = p.ToString();
            Assert.AreEqual(res1, "");
        }

        [TestMethod]
        public void ToString()
        {
            MusicalInstrument m = new MusicalInstrument("m", 44);
            Point<MusicalInstrument> p = new Point<MusicalInstrument>(m);
            var res1 = p.ToString();
            Assert.AreEqual(res1, "44: m,");
        }

    }

}