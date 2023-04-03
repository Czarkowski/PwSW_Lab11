using System;

namespace Drzewa
{
    public class DrzewoBinarne<T> where T : IComparable<T>
    {
        private class Wezel
        {
            public Wezel lewy;
            public Wezel prawy;
            public T dane;
            public Wezel(T x, Wezel lewy, Wezel prawy)
            {
                this.lewy = lewy;
                this.prawy = prawy;
                dane = x;
            }
        }

        private Wezel korzen = null;
        private int liczbyElementow = 0;

        public int LiczbaElementow
        {
            get { return liczbyElementow; }
        }

        public void Wstaw(T x)
        {
            liczbyElementow++;
            if (korzen == null)
            {
                korzen = new Wezel(x, null, null);
                return;
            }
            Wezel tmp = korzen, poprzedni;
            do
            {
                poprzedni = tmp;
                if (tmp.dane.CompareTo(x) < 0)
                {
                    tmp = tmp.prawy;
                }
                else
                {
                    tmp = tmp.lewy;
                }
            } while (tmp != null);

            if (poprzedni.dane.CompareTo(x) < 0)
            {
                poprzedni.prawy = new Wezel(x, null, null);
            }
            else
            {
                poprzedni.lewy = new Wezel(x, null, null);
            }

        }
        public bool Wyszukaj(T x)
        {
            Wezel tmp = korzen;
            while (tmp != null)
            {
                if (tmp.dane.CompareTo(x) == 0)
                {
                    return true;
                }
                else
                {
                    if (x.CompareTo(tmp.dane) < 0)
                    {
                        tmp = tmp.lewy;
                    }
                    else
                    {
                        tmp = tmp.prawy;
                    }
                }
            }
            return false;
        }
        public T[] ZamienNaTablice()
        {
            T[] tab = new T[LiczbaElementow];
            int n = 0;
            if (korzen != null)
            {
                zamienNaTablice(korzen.lewy, tab, ref n);
                tab[n] = korzen.dane;
                n++;
                zamienNaTablice(korzen.prawy, tab, ref n);
            }
            return tab;
        }
        private static void zamienNaTablice(Wezel w, T[] tab, ref int n)
        {
            if (w != null)
            {
                zamienNaTablice(w.lewy, tab, ref n);
                tab[n] = w.dane;
                n++;
                zamienNaTablice(w.prawy, tab, ref n);
            }
        }
    }
}
