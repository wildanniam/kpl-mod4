// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

internal class Program
{
    public enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }

    class KodePos
    {
        public static int getKodePos(Kelurahan kelurahan)
        {
            int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
            return kodePos[(int)kelurahan];
        }
    }

    public enum DoorState { TERKUNCI, TERBUKA };
    public enum Trigger { KUNCI_PINTU, BUKA_PINTU };

    public class DoorMachine
    {
        public DoorState currentState = DoorState.TERKUNCI;

        public class Transition
        {

            public DoorState stateAwal;
            public DoorState stateAkhir;
            public Trigger trigger;
            public Transition(DoorState stateAwal, DoorState stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }

        Transition[] transisi =
        {
            new Transition(DoorState.TERKUNCI, DoorState.TERKUNCI, Trigger.KUNCI_PINTU),
            new Transition(DoorState.TERKUNCI, DoorState.TERBUKA, Trigger.BUKA_PINTU),
            new Transition(DoorState.TERBUKA, DoorState.TERBUKA, Trigger.BUKA_PINTU),
            new Transition(DoorState.TERBUKA, DoorState.TERKUNCI, Trigger.KUNCI_PINTU),
        };

        public DoorState GetNextState(DoorState stateAwal, Trigger trigger)
        {
            DoorState stateAkhir = stateAwal;

            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];

                if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
            return stateAkhir;
        }

        public void ActivateTrigger(Trigger trigger)
        {

            if (trigger == Trigger.BUKA_PINTU)
            {
                Console.WriteLine("Anda melakukan aksi buka pintu");
            }
            else
            {
                Console.WriteLine("Anda melakukan penguncian pintu");
            }

            currentState = GetNextState(currentState, trigger);

            if (currentState == DoorState.TERBUKA)
            {
                Console.WriteLine("Pintu Anda Sekarang Terbuka!");
            }
            else
            {
                Console.WriteLine("Pintu Anda Sekarang Terkunci!");
            }
        }
    }

    public static void Main(string[] args)
    {
        DoorMachine objMhs = new DoorMachine();
        Console.WriteLine(objMhs.currentState);
        objMhs.ActivateTrigger(Trigger.KUNCI_PINTU);
        objMhs.ActivateTrigger(Trigger.BUKA_PINTU);
    }
}

