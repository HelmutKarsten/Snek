using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListardDemo;

namespace Snek
{
    class Snek
    {
        int initLocationX = 40;
        int initLocationY = 40;
        Listard<int[]> corpus = new Listard<int[]>();
        int[] theArray = new int[2] {0,0};


        public Snek()
        {   
            // initialisierung des Körpers
            initSnekLocation();                
        }

        public void initSnekLocation()
        {
            for (int i = 0; i <= 2; i++)
            {
                int tempLoc = initLocationX - i;
                theArray[0] = tempLoc;
                theArray[1] = initLocationY;
                //saveSnekLocation(tempLoc, initLocationY);
                corpus.Add(saveSnekLocation(tempLoc, initLocationY));
            }
        }

        public int getSnakeLength()
        { 
            return corpus.getCount();
        }

        public int[] saveSnekLocation(int locX, int locY)
        {
            int[] array = new int[2] {locX, locY};
            return array;
        }

        public int[] getCorpusPart(int partOfCorpus)
        {
            return corpus[partOfCorpus];
        }

        public void setCorpusPart(int partOfCorpus, int[] Coordinate)
        {
            corpus.Set(Coordinate, partOfCorpus);
        }

        public void addCorpusPart(int partOfCorpus, int[] Coordinate)
        {
            corpus.InsertAt(Coordinate, partOfCorpus);
        }

        public void letItGrow()
        {
            int[] corpusPartOne = getCorpusPart(0);
            //corpus.InsertAt(corpusPartOne, 1);
            //corpus.Add(corpusPartOne);
            addCorpusPart(1, corpusPartOne);
        }
        
    }
}
