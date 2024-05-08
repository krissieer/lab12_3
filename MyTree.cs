using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLab10;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab12_3
{
    public class MyTree<T> where T : IInit, IComparable, ICloneable, new() 
    {
        Point<T>? root = null;

        int count = 0;

        public int Count => count;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public MyTree() { }

        T minItem = default;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="length"></param>
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        /// <summary>
        /// Создание Идеально сбалансированного дерева
        /// </summary>
        /// <param name="length"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        Point<T> MakeTree(int length, Point<T>? point)
        {
            T data = new T();
            data.IRandomInit();
            Point<T> newItem = new Point<T>(data); //создаем текущий корень
            if (length == 0)
                return null;
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left); //формируем левое поддерево
            newItem.Right = MakeTree(nr, newItem.Right); //формируем правое поддерево
            return newItem;
        }

        /// <summary>
        /// Поиск минимального элемента
        /// </summary>
        /// <returns></returns>
        public T? SearchItem()
        {
            return FindMinItem(root);
        }
   
        /// <summary>
        /// Рекурсивный поиск минимальноого по названию элемента
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public T FindMinItem(Point<T> point)
        {
            if (point != null)
            {
                FindMinItem(point.Left);
                if (point.Data.CompareTo(minItem) < 0)
                    minItem = point.Data;
                FindMinItem(point.Right);
            }
            return minItem;
        }

        /// <summary>
        /// Реккрсивная печать 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="spaces"></param>
        void Print(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Print(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Print(point.Right, spaces + 5);
            }
        }

        /// <summary>
        /// Печать дерева
        /// </summary>
        public void PrintTree()
        {
            if (root == null) throw new Exception("Дерево пустое");
            else Print(root);

            Console.WriteLine(Count);
        }

        ///////////  Дерево поиска    ////////////

        public void AddPoint(T data)
        {
            Point<T>? point = root; // ставим ссылку на корень
            Point<T>? curr = null;
            bool isExist = false; // проверка существования элемента в дереве
            while (point != null && !isExist)
            {
                curr = point;
                if (point.Data.CompareTo(data) == 0) //добавляемый элемент уде есть в дереве
                    isExist = true;
                else
                {
                    if (point.Data.CompareTo(data) > 0) // если доб.элемент меньше текущего
                        point = point.Left; //сдвигаемся влево
                    else 
                        point = point.Right;
                }
            }
            if (isExist)
                return; //ничего не добавляем, так как элемент уже есть
            Point<T> newPoint = new Point<T>(data); //создаем новый элемент
            if (curr.Data.CompareTo(data) > 0)
                curr.Left = newPoint;
            else
                curr.Right = newPoint;
            count++;
        }

        /// <summary>
        /// Преобразование из ИСД  массив для получения дерева поиска
        /// </summary>
        /// <param name="point"></param>
        /// <param name="arr"></param>
        /// <param name="curr"></param>
        public void TransformToArr(Point<T>? point, T[]arr, ref int curr)
        {
            if (point != null)
            {
                TransformToArr(point.Left, arr, ref curr);
                arr[curr] = point.Data;
                curr++;
                TransformToArr(point.Right, arr, ref curr);
            }
        }

        public bool TransformToTree(MyTree<T> originTree)
        {
            if (originTree.root == null)
                return false;
            else
            {
                MyTree<T> clonedTree = CloneTree(originTree);
                T[] arr = new T[clonedTree.Count];
                int curr = 0;
                TransformToArr(clonedTree.root, arr, ref curr);
                root = new Point<T>(arr[0]);
                count = 1;
                for (int i = 1; i < arr.Length; i++)
                    AddPoint(arr[i]);
                return true;
            }
        }

        //public void DeletePoint(Point<T> point)
        //{
        //    if (point != null)
        //    {
        //        DeletePoint(point.Left);
        //        DeletePoint(point.Right);
        //        point = null;
        //    }
        //}

        public bool DeleteTree()
        { 
            if (root == null) return false;
            else
            {
                //DeletePoint(root);
                root = null;
                count = 0;
                return true;
            }
        }

        public Point<T> ClonePoint(Point<T>? point)
        {
            if (point == null)
                return null;
            else
            {
                Point<T> clonedPoint = new Point<T>((T)point.Data.Clone());
                clonedPoint.Left = ClonePoint(point.Left);
                clonedPoint.Right = ClonePoint(point.Right);
                return clonedPoint;
            }
        }

        public MyTree<T> CloneTree(MyTree<T> originTree)
        {
            if (originTree.Count != 0)
            {
                MyTree<T> clonedTree = new MyTree<T>(originTree.Count);
                clonedTree.root = ClonePoint(originTree.root);
                clonedTree.count = originTree.count;
                return clonedTree;
            }
            else
                return null;
        }


        public Point<T> FindPoint(Point<T> point, string name)
        {
            if (point == null)
                return null;

            else
            {
                if (point.Data is MusicalInstrument m)
                {
                    if (m.Name.Equals(name))
                        return point;
                    else
                    {
                        if (name.CompareTo(m.Name) < 0)
                            return FindPoint(point.Left, name);
                        if (name.CompareTo(m.Name) > 0)
                            return FindPoint(point.Right, name);
                    }
                }
            }    
            return null;
        }

        public Point<T> FindItem(MyTree<T> originTree, string name)
        {
            if (originTree.root == null)
                return null;

            return FindPoint(originTree.root, name);
        }

        public Point<T> RemovePoint(Point<T> point, T itemToDelete)
        {
            if (point == null)
                return null;

            else if (itemToDelete.CompareTo(point.Data) < 0) // если удаляемый эл-т меньше текущего, сдвиг в левое поддерево
            {
                point.Left = RemovePoint(point.Left, itemToDelete);
                return point;
            }
            else if (itemToDelete.CompareTo(point.Data) > 0) // если удаляемый эл-т больше текущего, сдвиг в правое поддерево
            {
                point.Right = RemovePoint(point.Right, itemToDelete);
                return point;
            }
            else
            {
                if (point.Data.Equals(itemToDelete))
                {
                    if (point.Left == null && point.Right == null) // если у эл-та нет потомков
                        return null; // удаляем этот элемент
                    else if (point.Left == null) // если у эл-та только правый потомок
                        return point.Right; //возвращаем правое поддерево
                    else if (point.Right == null) // если у эл-та только левый потомок
                        return point.Left; //возвращаем левое поддерево
                    else
                    {
                        // если в эл-та есть оба потомка
                        T minItem = FindMinValue(point.Right); // находим минимальный элемент в правом поддереве
                        point.Data = minItem;
                        point.Right = RemovePoint(point.Right, minItem);
                        return point;
                    }
                }
            }
            return point;
        }


        public bool RemoveItem(MyTree<T> originTree, T itemToDelete, string name)
        {
            if (FindItem(originTree, name) != null)
            {
                originTree.root = RemovePoint(originTree.root, itemToDelete);
                count--;
                return true;
            }
            else return false;
        }

        public T FindMinValue(Point<T> point)
        {
            T minValue = point.Data;
            while (point.Left != null)
            {
                minValue = point.Left.Data;
                point = point.Left;
                FindMinValue(point);
            }
            return minValue;
        }
    }
}
