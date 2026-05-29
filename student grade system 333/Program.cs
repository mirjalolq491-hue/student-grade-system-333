using System;

namespace StudentGradeSystem
{
    class Program
    {
        static int[] ids = new int[100];
        static string[] firstNames = new string[100];
        static string[] lastNames = new string[100];
        static int[] ages = new int[100];
        static string[] groups = new string[100];
        static double[] mathGrades = new double[100];
        static double[] engGrades = new double[100];
        static double[] progGrades = new double[100];
        static bool[] hasGrades = new bool[100];


        static int count = 0;
        static int nextId = 1;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool running = true;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": ShowAllStudents(); break;
                    case "3": AddGrades(); break;
                    case "4": ShowAverages(); break;
                    case "5": ShowTopStudent(); break;
                    case "6": ShowFailedStudents(); break;
                    case "7": SearchStudent(); break;
                    case "0":
                        ShowLine('=', 42);
                        Console.WriteLine("  Dasturdan chiqilmoqda... Xayr!");
                        ShowLine('=', 42);
                        running = false;
                        break;
                    default:
                        WriteColored("  [!] Noto'g'ri tanlov. Qaytadan urinib ko'ring.", ConsoleColor.Red);
                        break;
                }

                if (running)
                {
                    Console.WriteLine();
                    WriteColored("  Davom etish uchun Enter bosing...", ConsoleColor.DarkGray);
                    Console.ReadLine();
                }
            }
        }

        static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowLine('=', 42);
            Console.WriteLine("        STUDENT GRADE SYSTEM");
            ShowLine('=', 42);
            Console.ResetColor();

            PrintMenuItem("1", "Talaba qo'shish");
            PrintMenuItem("2", "Talabalarni ko'rish");
            PrintMenuItem("3", "Baho qo'shish");
            PrintMenuItem("4", "O'rtacha bahoni hisoblash");
            PrintMenuItem("5", "Eng yaxshi talabani topish");
            PrintMenuItem("6", "Failed studentlar");
            PrintMenuItem("7", "Talaba qidirish");
            Console.ForegroundColor = ConsoleColor.Red;
            PrintMenuItem("0", "Exit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowLine('=', 42);
            Console.ResetColor();
            Console.Write("  Tanlovingiz: ");
        }

        static void PrintMenuItem(string num, string label)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"  {num,2}.");
            Console.ResetColor();
            Console.WriteLine($" {label}");
        }

        // 1. TALABA QO'SHISH
        static void AddStudent()
        {
            SectionHeader("TALABA QO'SHISH");

            if (count >= 100)
            {
                WriteColored("  [!] Maksimal talabalar soni (100) to'ldi.", ConsoleColor.Red);
                return;
            }

            string firstName = ReadNonEmpty("  Ism       : ");
            string lastName = ReadNonEmpty("  Familiya  : ");

            // Duplicate tekshiruv
            if (IsDuplicate(firstName, lastName))
            {
                WriteColored($"\n  [!] '{firstName} {lastName}' allaqachon ro'yxatda mavjud!", ConsoleColor.Red);
                return;
            }

            int age = ReadInt("  Yosh       : ", 10, 100);
            string group = ReadNonEmpty("  Guruh     : ");

            ids[count] = nextId++;
            firstNames[count] = firstName;
            lastNames[count] = lastName;
            ages[count] = age;
            groups[count] = group;
            hasGrades[count] = false;
            count++;

            WriteColored($"\n  Talaba muvaffaqiyatli qo'shildi! (ID: {ids[count - 1]})", ConsoleColor.Green);
        }

        // Duplicate tekshiruvchi metod
        static bool IsDuplicate(string firstName, string lastName)
        {
            for (int i = 0; i < count; i++)
            {
                if (firstNames[i].Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    lastNames[i].Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        // 2. TALABALARNI KO'RISH
        static void ShowAllStudents()
        {
            SectionHeader("BARCHA TALABALAR");

            if (count == 0) { EmptyList(); return; }

            PrintTableHeader();
            for (int i = 0; i < count; i++)
                PrintStudentRow(i);
            ShowLine('-', 64);
            WriteColored($"\n  Jami: {count} ta talaba", ConsoleColor.Cyan);
        }

        // 3. BAHO QO'SHISH
        static void AddGrades()
        {
            SectionHeader("BAHO QO'SHISH");

            if (count == 0) { EmptyList(); return; }

            int id = ReadInt("  Talaba ID  : ", 1, int.MaxValue);
            int idx = FindById(id);

            if (idx == -1)
            {
                WriteColored("  [!] Bunday ID li talaba topilmadi.", ConsoleColor.Red);
                return;
            }

            Console.WriteLine($"\n  Talaba: {firstNames[idx]} {lastNames[idx]}");
            mathGrades[idx] = ReadDouble("  Matematika  (0-100): ", 0, 100);
            engGrades[idx] = ReadDouble("  Ingliz tili (0-100): ", 0, 100);
            progGrades[idx] = ReadDouble("  Dasturlash  (0-100): ", 0, 100);
            hasGrades[idx] = true;

            double avg = CalcAverage(idx);
            WriteColored($"\n  Baholar saqlandi. O'rtacha: {avg:F2}", ConsoleColor.Green);
        }

        // 4. O'RTACHA BAHOLAR
        static void ShowAverages()
        {
            SectionHeader("O'RTACHA BAHOLAR");

            if (count == 0) { EmptyList(); return; }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"  {"ID",-5} {"F.I.SH",-25} {"Math",-8} {"Eng",-8} {"Prog",-8} {"O'rtacha",-10}");
            ShowLine('-', 68);
            Console.ResetColor();

            for (int i = 0; i < count; i++)
            {
                string full = $"{firstNames[i]} {lastNames[i]}";
                if (hasGrades[i])
                {
                    double avg = CalcAverage(i);
                    ConsoleColor c = avg >= 85 ? ConsoleColor.Green
                                   : avg >= 60 ? ConsoleColor.White
                                   : ConsoleColor.Red;
                    Console.ForegroundColor = c;
                    Console.WriteLine($"  {ids[i],-5} {full,-25} {mathGrades[i],-8:F1} {engGrades[i],-8:F1} {progGrades[i],-8:F1} {avg,-10:F2}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"  {ids[i],-5} {full,-25} {"--",-8} {"--",-8} {"--",-8} {"Baho yo'q",-10}");
                    Console.ResetColor();
                }
            }
            ShowLine('-', 68);
        }

        // 5. ENG YAXSHI TALABA
        static void ShowTopStudent()
        {
            SectionHeader("ENG YAXSHI TALABA");

            int idx = FindTopStudentIndex();
            if (idx == -1) { WriteColored("  Baholar kiritilmagan.", ConsoleColor.Yellow); return; }

            double avg = CalcAverage(idx);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ID        : {ids[idx]}");
            Console.WriteLine($"  F.I.SH    : {firstNames[idx]} {lastNames[idx]}");
            Console.WriteLine($"  Guruh     : {groups[idx]}");
            Console.WriteLine($"  Math      : {mathGrades[idx]:F1}");
            Console.WriteLine($"  Ingliz    : {engGrades[idx]:F1}");
            Console.WriteLine($"  Dasturlash: {progGrades[idx]:F1}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  O'rtacha  : {avg:F2}");
            Console.ResetColor();
        }

        // 6. FAILED STUDENTLAR
        static void ShowFailedStudents()
        {
            SectionHeader("FAILED STUDENTLAR (O'rtacha < 60)");

            bool found = false;
            PrintTableHeader();

            for (int i = 0; i < count; i++)
            {
                if (hasGrades[i] && CalcAverage(i) < 60)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintStudentRow(i);
                    Console.ResetColor();
                    found = true;
                }
            }

            if (!found)
                WriteColored("\n  Barcha talabalar (bahosi bor) o'tgan.", ConsoleColor.Green);
            else
                ShowLine('-', 64);
        }

        // 7. TALABA QIDIRISH
        static void SearchStudent()
        {
            SectionHeader("TALABA QIDIRISH");

            Console.Write("  Ism yoki ID kiriting: ");
            string query = Console.ReadLine()?.Trim() ?? "";
            if (query == "") return;

            bool found = false;
            PrintTableHeader();

            for (int i = 0; i < count; i++)
            {
                string full = $"{firstNames[i]} {lastNames[i]}";
                if (full.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    ids[i].ToString() == query)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintStudentRow(i);
                    Console.ResetColor();
                    found = true;
                }
            }

            if (!found)
                WriteColored("\n  Talaba topilmadi.", ConsoleColor.Red);
            else
                ShowLine('-', 64);
        }

        // YORDAMCHI METODLAR

        static double CalcAverage(int idx)
            => (mathGrades[idx] + engGrades[idx] + progGrades[idx]) / 3.0;

        static int FindById(int id)
        {
            for (int i = 0; i < count; i++)
                if (ids[i] == id) return i;
            return -1;
        }

        static int FindTopStudentIndex()
        {
            int best = -1;
            double bestAvg = -1;
            for (int i = 0; i < count; i++)
            {
                if (!hasGrades[i]) continue;
                double avg = CalcAverage(i);
                if (avg > bestAvg) { bestAvg = avg; best = i; }
            }
            return best;
        }

        static void PrintTableHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            ShowLine('-', 64);
            Console.WriteLine($"  {"ID",-5} {"F.I.SH",-28} {"Guruh",-12} {"O'rtacha"}");
            ShowLine('-', 64);
            Console.ResetColor();
        }

        static void PrintStudentRow(int i)
        {
            string full = $"{firstNames[i]} {lastNames[i]}";
            string avg = hasGrades[i] ? CalcAverage(i).ToString("F2") : "---";
            Console.WriteLine($"  {ids[i],-5} {full,-28} {groups[i],-12} {avg}");
        }

        static void SectionHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowLine('=', 42);
            Console.WriteLine($"  {title}");
            ShowLine('=', 42);
            Console.ResetColor();
        }

        static void ShowLine(char ch, int len)
            => Console.WriteLine(new string(ch, len));

        static void WriteColored(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void EmptyList()
            => WriteColored("  Hali hech qanday talaba qo'shilmagan.", ConsoleColor.Yellow);

        static string ReadNonEmpty(string prompt)
        {
            string val;
            do
            {
                Console.Write(prompt);
                val = Console.ReadLine()?.Trim() ?? "";
                if (val == "") WriteColored("  [!] Bo'sh qoldirish mumkin emas.", ConsoleColor.Red);
            } while (val == "");
            return val;
        }

        static int ReadInt(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                WriteColored($"  [!] {min} - {max} oraliqda butun son kiriting.", ConsoleColor.Red);
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                    return result;
                WriteColored($"  [!] {min} - {max} oraliqda son kiriting.", ConsoleColor.Red);
            }
        }
    }
}
