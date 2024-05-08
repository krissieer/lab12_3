using ClassLibraryLab10;

namespace lab12_3
{
    internal class Program
    {
        static public MyTree<MusicalInstrument> CreateTree(MyTree<MusicalInstrument> balancedTree)
        {
            int length;
            Console.WriteLine("Введите длину дерева: ");
            bool isCorrect = int.TryParse(Console.ReadLine(), out length);
            if (!isCorrect || length <= 0)
                Console.WriteLine("Неправильно задана длина дерева");
            else
            {
                balancedTree = new MyTree<MusicalInstrument>(length);
                Console.WriteLine("Дерево сформировано");
            }
            return balancedTree;    
        }

        static public void DeleteItem(MyTree<MusicalInstrument> searchTree)
        {
            string name;
            Console.WriteLine("Введите название инструмента: ");
            name = Console.ReadLine();
            Point<MusicalInstrument> item = searchTree.FindItem(searchTree, name);

            if (item != null)
            {
                bool isDeleted = searchTree.RemoveItem(searchTree, item.Data, name);
                if (isDeleted)
                {
                    Console.WriteLine($"Элемент с названием {name} - удален из дерева");
                }
            }
            else
            {
                Console.WriteLine($"Элемента с именем '{name}' нет в дереве");
            }
        }


        static public void PrintAndCheckClone(MyTree<MusicalInstrument> searchTree, MyTree<MusicalInstrument> clonedTree)
        {
            Console.WriteLine(" === Печать клона дерева поиска === ");
            if (searchTree.CloneTree(searchTree) != null)
            {
                clonedTree.PrintTree();
                Console.WriteLine();
                Console.WriteLine("Клон дерева поиска c доб.элементом");
                clonedTree.AddPoint(new MusicalInstrument("новый элемент", 666));
                clonedTree.PrintTree();
            }
            else
            {
                Console.WriteLine("Исходное дерево пустое");
            }
        }

        static void Main(string[] args)
        {
            MyTree<MusicalInstrument> balancedTree = new MyTree<MusicalInstrument>();
            MyTree<MusicalInstrument> searchTree = new MyTree<MusicalInstrument>();
            MyTree<MusicalInstrument> clonedTree = new MyTree<MusicalInstrument>();

            int ans;
            bool isConvert;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Создание идеально сбалансированного дерева");
                Console.WriteLine("2. Печать ИСД");
                Console.WriteLine("3. Найти минимальный элемент (по названию)");
                Console.WriteLine("4. Преобразование ИСД в дерево поиска");
                Console.WriteLine("5. Печать дерева поиска");
                Console.WriteLine("6. Удаление дерева поиска из памяти");
                Console.WriteLine("7. Клонирование дерева поиска");
                Console.WriteLine("8. Печать клона");
                Console.WriteLine("9. Удаление из дерева поиска элемента с заданным ключеом");
                Console.WriteLine("0. Закончить работу");
                Console.WriteLine();

                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out ans);
                    Console.WriteLine();
                    if (!isConvert)
                        Console.WriteLine("Число введено неправильно. Введите число еще раз");
                } while (!isConvert);

                switch(ans)
                {
                    case 1: // Создание идеально сбалансированного дерева
                        {
                            balancedTree = CreateTree(balancedTree);
                            break;
                        }

                    case 2: // Печать ИСД
                        {
                            Console.WriteLine(" ==== Идеально сбалансированное дерево === ");
                            try
                            {
                                balancedTree.PrintTree();
                            }
                            catch (Exception ex) { Console.WriteLine($"\n Исключение: {ex.Message}"); }
                            break;
                        }

                    case 3: // Найти минимальный элемент (по названию элемента)
                        {
                            Console.WriteLine(" === Минимальный по названию элемент в дереве === ");

                            if (balancedTree.SearchItem() != null)
                                Console.WriteLine(balancedTree.SearchItem());
                            else
                                Console.WriteLine("Дерево пустое");
                            break;
                        }

                    case 4: // Преобразование ИСД в дерево поиска
                        {
                            bool checkTransformed = searchTree.TransformToTree(balancedTree);
                            if (checkTransformed)
                                Console.WriteLine("Дерево поиска сформировано");
                            else
                                Console.WriteLine("Дерево пустое");
                            break;
                        }

                    case 5: // Печать дерева поиска
                        {
                            Console.WriteLine(" === Дерево поиска ===");
                            try
                            {
                                searchTree.PrintTree();
                            }
                            catch (Exception ex) { Console.WriteLine($"\n Исключение: {ex.Message}"); }
                            break;
                        }

                    case 6: // Удаление дерева поиска из памяти
                        {
                            if (!searchTree.DeleteTree())
                                Console.WriteLine("Дерево пустое");
                            else
                                Console.WriteLine("Дерево поиска удалено");
                            break;
                        }

                    case 7: // Клонирование
                        {
                            Console.WriteLine(" === Создание клона дерева поиска === ");
                            if (searchTree.CloneTree(searchTree) != null)
                            {
                                clonedTree = searchTree.CloneTree(searchTree);
                                Console.WriteLine("Дерево поиска склониравано");
                            }
                            else
                                Console.WriteLine("Исходное дерево пустое");
                            break;
                        }

                    case 8: // Печать клона
                        {
                            PrintAndCheckClone(searchTree, clonedTree);
                            break;
                        }

                    case 9:
                        {
                            DeleteItem(searchTree);
                            break;
                        }
                }
            } while (ans != 0);
        }
    }
}
