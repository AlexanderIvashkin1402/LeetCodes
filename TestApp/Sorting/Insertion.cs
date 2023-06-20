using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Sorting
{
    internal class Insertion
    {
        public void Sort(int[] array)
        {
            var length = array.Length;
            for (int i = 1; i < length; i++)
            {
                var key = array[i];
                var flag = true;
                for (int j = i - 1; j >= 0 && flag;)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = key;
                    }
                    else flag = false;
                }
            }
        }
        public void SortSplice(int[] array)
        {
            var length = array.Length;
            for (var i = 0; i < length; i++)
            {
                if (array[i] < array[0])
                {
                    //move number to the first position
                    //array.unshift(array.splice(i, 1)[0]);
                }
                else
                {
                    // only sort number smaller than number on the left of it. This is the part of insertion sort that makes it fast if the array is almost sorted.
                    if (array[i] < array[i - 1])
                    {
                        //find where number should go
                        for (var j = 1; j < i; j++)
                        {
                            if (array[i] >= array[j - 1] && array[i] < array[j])
                            {
                                //move number to the right spot
                               // array.splice(j, 0, array.splice(i, 1)[0]);
                            }
                        }
                    }
                }
            }
        }
    }
}

/*
const numbers = [99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0];

function insertionSort(array) {
  const length = array.length;
	for (let i = 0; i < length; i++) {
		if (array[i] < array[0]) {
      //move number to the first position
      array.unshift(array.splice(i,1)[0]);
    } else {
      // only sort number smaller than number on the left of it. This is the part of insertion sort that makes it fast if the array is almost sorted.
      if (array[i] < array[i-1]) {
        //find where number should go
        for (var j = 1; j < i; j++) {
          if (array[i] >= array[j-1] && array[i] < array[j]) {
            //move number to the right spot
            array.splice(j,0,array.splice(i,1)[0]);
          }
        }
      }
    }
	}
}

insertionSort(numbers);
console.log(numbers);
 */
