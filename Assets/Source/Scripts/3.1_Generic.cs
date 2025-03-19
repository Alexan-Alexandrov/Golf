using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Generic : MonoBehaviour
{
    // Start is called before the first frame update
    public class MyClass
    {
        public int i;
        public int j;
    }

    public struct MyStruct
    {
        public string name;
        public int age;
    }


    public class MyList<Titem>
    {
        public Titem[] array = new Titem[4];
        public int maxCount = 25;
        public int count = 0; // кол-во заполненных объектов


        public void Resize(int amount) //Изеняет размер массива
        {
            if (Mathf.Clamp(amount, 0, maxCount) != array.Length)
            {
                Array.Resize(ref array, amount);
                UnityEngine.Debug.Log("Ячейки изменились");
                return;
            }
            else
            {
                UnityEngine.Debug.Log("Ячейки переполнены, расширение невозможно");
                return;
            }
        }

        public void AddItem(Titem item) // Добавляет объект в свободную ячейку, если такая есть
        {

            if (count < array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == null)
                    {
                        array[i] = item;
                        UnityEngine.Debug.Log("Объект добавлен");
                        count++;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ячейки переполнены");
            }
        }

        public void RemoveIndex(int item)
        {
            if (item >= 0 && item < array.Length)
            {
                if (array[item] != null)
                {
                    array[item] = default(Titem);
                    count--;
                    UnityEngine.Debug.Log("Объект Удален");
                    return;
                }
            }
            return;
        } //Удаляет объект из выбранной ячейки

        public void ClearAll() // очищает весь массив
        {
            for (int i = 0; i< array.Length; i++)
            {
                array[i] = default(Titem);
            }
            count = 0;
            UnityEngine.Debug.Log("Объект удалены");
        }

        public int IndexOf(Titem item) // ищет индекс объекта, если не находит, выводит -1
        {
            if (item != null)
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    if (array[i] != null && array[i].Equals(item))
                    {
                        UnityEngine.Debug.Log ("Найден индекс под номером - " + i);
                        return i;
                    }
                }

            }
                return -1;
        }

        
    }

    
 
    void Start()
    {
        MyList<MyClass> myList = new MyList<MyClass>();
        MyClass obj1 = new MyClass();
        MyClass obj2 = new MyClass();

        myList.AddItem(obj1);
        myList.AddItem(obj2);
        UnityEngine.Debug.Log("Кол-во ячеек - "  + myList.array.Length);
        UnityEngine.Debug.Log("Заполнено ячеек - "  + myList.count);
        myList.Resize(10);
        UnityEngine.Debug.Log("Кол-во ячеек - " + myList.array.Length);
        myList.RemoveIndex(myList.IndexOf(obj1));
        UnityEngine.Debug.Log("Кол-во ячеек - " + myList.array.Length);
        UnityEngine.Debug.Log("Заполнено ячеек - " + myList.count);


    }
}