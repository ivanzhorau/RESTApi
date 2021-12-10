using RESTApi.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RESTApi.FileWorker
{
    public class JSONOuter : IOuter
        //варта было б гэты клас разбіць на 2: нерасрэдны запіс ў файл(таксама інтэрфэйсам) і апрацоўка масіва
        // Ну гэта  задзеля падтрымкі коду ў будучыні, але ж ён пішацца на адзін раз
        // Я бы навогул без інтэрфэйсаў рабіў, ды й падзабіў бы на SOLID. Але ў мінулы раз за такое вашая ж кампанія мне адмовіла ў супрацоўніцтве
        // Таму рушым у бок softcod'у ) 
    {
        private string filename;
        public void setPath(string filename) => this.filename = filename;
        private async void Write(IList<ILot> lots)
        {
            string json = JsonSerializer.Serialize<ILot[]>(lots.ToArray());
            File.WriteAllText(filename, string.Empty);

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {

                byte[] array = System.Text.Encoding.UTF8.GetBytes(json);

                await fs.WriteAsync(array, 0, array.Length);

            }
        }
        public void Add(ILot lot)
        {
            ILot[] tArr = Read().ToArray<ILot>();
            ILot[] newTArr = new ILot[tArr.Length + 1];
            for (int i = 0; i < tArr.Length; i++)
            {
                newTArr[i] = tArr[i];
            }
            newTArr[tArr.Length] = lot;
            if (tArr.Length != 0)
                newTArr[tArr.Length].ID = newTArr[tArr.Length - 1].ID + 1;
            else
                newTArr[tArr.Length].ID = 0;
            Write(newTArr);
        }

        public void Change(ILot lot)
        {
            ILot[] lots = Read().ToArray<ILot>();
            for (int i = 0; i < lots.Length; i++)
            {
                if (lots[i].ID == lot.ID)
                {
                    lots[i] = lot;
                }
            }
            Write(lots);

        }

        public void Del(ILot lot)
        {
            ILot[] lots = Read().ToArray<ILot>();
            ILot[] newLots = new ILot[lots.Length - 1];
            int i = 0;
            for (; lots[i].ID != lot.ID; i++)
            {
                newLots[i] = lots[i];
            }
            for (; i < newLots.Length; i++)
            {
                newLots[i] = lots[i + 1];
            }

            Write(newLots);
        }

        public IList<ILot> Read()
        {
            ILot[] t;
            try
            {
                using (FileStream fstream = File.OpenRead(filename))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    t = JsonSerializer.Deserialize<Lot[]>(array);

                }
            }
            catch (Exception e) {
                t = new Lot[1] { new Lot { ID = 0, Text="ERRATUM",ImagePath= "https://sun9-65.userapi.com/impg/S1k4FA0E8oWmqHSFpQVR-d-wKsXvAZwcy9w91g/9YEwsO_2ggc.jpg?size=750x827&quality=96&sign=b766ae39e4af4e3dad5f1486710bc1fe&type=album" } };
            }
            return t;
        }
    }
}
