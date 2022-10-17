using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class Program
    {
        static int Health;
        static int Shield;
        static int Lives;
        static int Level;
        static int XP;
        static int MaxHealth = 20;
        static int MaxShield = 10;

        static void Main(string[] args)
        {
            Health = MaxHealth;
            Shield = MaxShield;
            Lives = 3;
            Level = 1;
            XP = 0;
            int Damage = 15;
            int HealAmount = 20;
            ShowHUD();
            Console.ReadKey(true);
            TakeDamage(Damage);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

            Heal(HealAmount);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

        }
        static void ShowHUD()
        {
            int XPToLevelUp = 20;
            Console.WriteLine("\n Lives: " + Lives + "   Level: " + Level + "   XP: " + XP + "   XP to Next Level: " + (XPToLevelUp - XP));
            Console.WriteLine("\n ----------------------------------------------------------------\n");
            Console.WriteLine(" Health: " + Health + "  Shield:  " + Shield + "\n");
            
        }

        static void TakeDamage(int DamageAmount)
        {
            int TempDamage;
            Console.WriteLine("Player is about to take (" + DamageAmount + ") Damage");
            if (DamageAmount < 0)
            {
                Console.WriteLine("Error - DamageAmount Varible Does not equel a Positive Number");
            }
            else
            {
                TempDamage = DamageAmount - Shield;

                Shield = Shield - DamageAmount;

                if (Shield <= 0)
                {
                    Shield = 0;

                    if (TempDamage > 0)  Health = Health - TempDamage;
                }

                Console.WriteLine("Player Took (" + DamageAmount + ") Damage");

                if (Health <= 0)
                {
                    Health = MaxHealth;
                    Lives = Lives - 1;
                    Console.WriteLine("Player Lost a Live");
                }
                    
            }
        }

        static void Heal(int HealAmount)
        {
            int TempHealth;
            Console.WriteLine("Player is about to Heal (" + HealAmount + ") Health");

            if (HealAmount < 0)
            {
                Console.WriteLine("Error - HealAmount Varible Does not equel a Positive Number");
            }
            else
            {
                TempHealth = Health;
                Health = Health + HealAmount;
                if (Health >= MaxHealth)
                {
                    TempHealth = MaxHealth - TempHealth; 
                    Health = MaxHealth;
                }
                Console.WriteLine("Player Healed (" + TempHealth + ") Health");
            }
            
        }

    }
}
