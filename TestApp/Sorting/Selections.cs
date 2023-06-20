using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Sorting
{
    internal class Selections
    {
        public void Sort(int[] array)
        {
            var length = array.Length;
            for (var i = 0; i < length; i++)
            {
                // set current index as minimum
                var minIndex = i;
                var temp = array[i];
                for (var j = i + 1; j < length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        //update minimum if current is lower that what we had previously
                        minIndex = j;
                    }
                }
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }
}

/*
const numbers = [99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0];

function selectionSort(array) {
  const length = array.length;
  for(let i = 0; i < length; i++){
    // set current index as minimum
    let min = i;
    let temp = array[i];
    for(let j = i+1; j < length; j++){
      if (array[j] < array[min]){
        //update minimum if current is lower that what we had previously
        min = j;
      }
    }
    array[i] = array[min];
    array[min] = temp;
  }
  return array;
}

selectionSort(numbers);
console.log(numbers);
 */
