//Codul functioneaza si pentru baze mai mari de 16.
using System;

public class Ardeli
{ 
    //funcite pentru a returna codul ascii 
    //al unui caracter
    static int val(char c)
    {
        if (c >= '0' && c <= '9')
            return (int)c - '0';
        else
            return (int)c - 'A' + 10;
    }

    //functie pentru convertirea unui numar
    //dintr-o baza data in zecimal 
    static int inDeci(string str, int b_aza)
    {

        //numarul o sa fie stocat ca si string
        int len = str.Length;

       
        int power = 1;
        int num = 0;


        //str[len-1]*1 + str[len-2]*basse + str[len-3]*(basse^2) + ...
        for (int i = len - 1; i >= 0; i--)
        {

            // o cifra a numarului dat trebuie 
            // sa fie mai mica decat baza data 
            if (val(str[i]) >= b_aza)
            {
                Console.WriteLine("Baza este prea mica");
                return -1;
            }

            
            num += val(str[i]) * power;
            power = power * b_aza;
        }
        return num;
    }

    //fuctie care imi transforma da valoarea
    //codului sau ascii
    static char reVal(int num)
    {
        if (num >= 0 && num <= 9)
            return (char)(num + '0');
        else
            return (char)(num - 10+ 'A');
    }

   //functie de convertire din baza 10 in alta baza
    static string dinDeci(int basse, int inputNum)
    {

        string res = "";

        
        while (inputNum > 0)
        {

            
            res += reVal(inputNum % basse);
            inputNum /= basse;
        }

        res = reverse(res);

        return res;
    }

    //functie ce imi ponvertesti un numar dintr-o baza in alta baza
    static void convertb_aza(string s, int a, int b)
    {

        //numarul trebuie schimbat dim baza a in baza 10
        int num = inDeci(s, a);

        //din baza 10 in baza b
        string ans = dinDeci(b, num);

        Console.WriteLine(ans);
    }

    static string reverse(string str)
    {
        char[] a = str.ToCharArray();
        int l, r = a.Length - 1;
        for (l = 0; l < r; l++, r--)
        {
            char temp = a[l];
            a[l] = a[r];
            a[r] = temp;
        }
        return new string(a);
    }
    //Cod comanda
    static public void Main()
    {
        Console.WriteLine("Va rog sa introduceti numarul dorit");
        string s = Console.ReadLine();
        Console.WriteLine("Va rog sa precizati baza");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Introduceti noua baza in care vreti sa scrieti numarul");
        int b = int.Parse(Console.ReadLine());

        convertb_aza(s, a, b);
    }
}

