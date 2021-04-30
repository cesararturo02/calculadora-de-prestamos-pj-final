using System;
using System.Collections.Generic;

namespace caculadora_de_prestamos
{
    class DatosDelPrestamo
    {
        public double Cuota 
        { get; set; }

        public double Capital 
        { get; set; }

        public double Interes 
        { get; set; }

        public double Balance 
        { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double Monto;
            do
            {
                Console.WriteLine("Introduzca el Monto del préstamo:");
                Monto = Convert.ToDouble(Console.ReadLine());
            } while (Monto <= 0);

            double Intereses;
            do
            {
                Console.WriteLine("Tasa de porcentaje Anual en %:");
                Intereses = Convert.ToDouble(Console.ReadLine());
            } while (Intereses <= 0);

            Intereses = Intereses / 1200;

            int Plazo;
            do
            {
                Console.WriteLine("Introduzca el Plazo para pagar el préstamo:");
                Plazo = Convert.ToInt32(Console.ReadLine());
            } while (Plazo <= 0);

            double[] InteresesM = new double[Plazo];
            double[] CapitalM = new double[Plazo];
            double[] BalanceM = new double[Plazo];

            double Cuota = CalcularCuotaM(Intereses, Plazo, Monto);
            InteresesM = CalcularInteresesM(Intereses, Plazo, Monto, Cuota);
            CapitalM = CalcularCapitalM(Intereses, Plazo, Monto, Cuota);
            BalanceM = CalcularBalancesM(Intereses, Plazo, Monto, Cuota);

            int K;
            int n;
            int p = Plazo - 1;
            Console.WriteLine("Pago No.       Cuota Fija        Capital           Interes           Balance");
            for (K = 0; K <= p; K++)
            {
                n = K;
                PublicarTabla(InteresesM[K], CapitalM[K], BalanceM[K], Cuota, n);
            }
            Console.ReadKey();
        }
        
        #region Metodos
        static double CalcularCuotaM(double Intereses, int Plazos, double Monto)
        {
            double Q = Math.Pow((1 + Intereses), Plazos);
            double Cuota = Intereses * Monto * Q / (Q - 1);
            return Cuota;
        }

        static double[] CalcularCapitalM(double Intereses, int Plazos, double Monto, double Cuota)
        {
            double[] InteresesMs = new double[Plazos];
            double[] CapitalMs = new double[Plazos];
            double[] BalanceMs = new double[Plazos];
            int L;
            double MontoI = Monto;
            double Capital;
            double IntMens;
            double Balance;
            
            Plazos--;
            for (L = 0; L <= Plazos; L++)
            {
                IntMens = MontoI * Intereses;
                InteresesMs[L] = IntMens;
                Capital = Cuota - IntMens;
                CapitalMs[L] = Capital;
                Balance = MontoI - Capital;
                BalanceMs[L] = Balance;
                MontoI = Balance;
            }
            return CapitalMs;
        }

        static double[] CalcularInteresesM(double Intereses, int Plazos, double Monto, double Cuota)
        {
            double[] InteresesMs = new double[Plazos];
            double[] CapitalMs = new double[Plazos];
            double[] BalanceMs = new double[Plazos];
            int L;
            double MontoI = Monto;
            double Capital;
            double IntMens;
            double Balance;
            Plazos--;

            for (L = 0; L <= Plazos; L++)
            {
                IntMens = MontoI * Intereses;
                InteresesMs[L] = IntMens;
                Capital = Cuota - IntMens;
                CapitalMs[L] = Capital;
                Balance = MontoI - Capital;
                BalanceMs[L] = Balance;
                MontoI = Balance;
            }
            return InteresesMs;
        }
        
        static double[] CalcularBalancesM(double Intereses, int Plazos, double Monto, double Cuota)
        {
            double[] InteresesMs = new double[Plazos];
            double[] CapitalMs = new double[Plazos];
            double[] BalanceMs = new double[Plazos];
            int L;
            double MontoI = Monto;
            double Capital;
            double IntMens;
            double Balance;
            Plazos--;

            for (L = 0; L <= Plazos; L++)
            {
                IntMens = MontoI * Intereses;
                InteresesMs[L] = IntMens;
                Capital = Cuota - IntMens;
                CapitalMs[L] = Capital;
                Balance = MontoI - Capital;
                BalanceMs[L] = Balance;
                MontoI = Balance;
            }
            return BalanceMs;
        }

        static void PublicarTabla(double InteresesM, double CapitalM, double BalanceM, double Cuota, int h)
        {
            h++;
            DatosDelPrestamo d;

            List<DatosDelPrestamo> ListaDatos = new List<DatosDelPrestamo>();
            {
                d = new DatosDelPrestamo() { Cuota = Cuota, Capital = CapitalM, Interes = InteresesM, Balance = BalanceM };
                ListaDatos.Add(d);
                Console.WriteLine(h + "         ||    "  + decimal.Round(Convert.ToDecimal(ListaDatos[0].Cuota), 2) +  "     ||     "  + decimal.Round(Convert.ToDecimal(ListaDatos[0].Capital), 2) +  "     ||     "  + decimal.Round(Convert.ToDecimal(ListaDatos[0].Interes), 2) +  "     ||     "  + decimal.Round(Convert.ToDecimal(ListaDatos[0].Balance), 2));
            }
        }
        #endregion Métodos
    }
    
}