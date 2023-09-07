using System.Diagnostics;
using System.Text.Json;
using System.Timers;

namespace Loadshedding_Scheduler
{
    public partial class Form1 : Form
    {
        List<LoadSheddingData> lsData;

        public static System.Timers.Timer shutdownSchedule = new System.Timers.Timer(1000); // set to 1 seconds
        public static System.Timers.Timer updateSchedule = new System.Timers.Timer(60000); // set to 60 seconds
        public static System.Timers.Timer countdownSchedule = new System.Timers.Timer(1000); // set to 1 seconds

        public string area;

        public bool init = false;

        public string action;

        public Form1()
        {
            InitializeComponent();

            actionDropdown.SelectedIndex = 0;
            warnInterval.SelectedIndex = 2;
            action = actionDropdown.Text;

            _ = get_loadshedding_schedule();

            shutdownSchedule.Elapsed += shutdownSchedule_Elaspsed;
            shutdownSchedule.Enabled = true;
            shutdownSchedule.Start();

            updateSchedule.Elapsed += updateSchedule_Elapsed;
            updateSchedule.Enabled = true;
            updateSchedule.Start();

            countdownSchedule.Elapsed += countdownSchedule_Elapsed;
            countdownSchedule.Enabled = true;
            countdownSchedule.Start();
        }

        private void countdownSchedule_Elapsed(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                try
                {
                    if (area == null) { return; }

                    DateTime dtStart = lsData.OrderBy(x => x.dt_start).First(x => x.area == area && x.dt_start > DateTime.Now).dt_start;

                    TimeSpan dtDiff = dtStart - DateTime.Now;

                    countdownTimer.Text = string.Format("{0}d, {1}h, {2}m, {3}s.", dtDiff.Days, dtDiff.Hours, dtDiff.Minutes, dtDiff.Seconds);
                }
                catch (Exception)
                {

                    return;
                }
            }));
        }

        private void updateSchedule_Elapsed(object? sender, ElapsedEventArgs e)
        {
            _ = get_loadshedding_schedule();

            Invoke(new Action(() =>
            {
                try
                {
                    area = areaComboBox.Text; statusLabel.Text = lsData.OrderBy(x => x.dt_start).First(x => x.area == area && x.dt_start > DateTime.Now).stage;
                    nextLabel.Text = lsData.OrderBy(x => x.dt_start).First(x => x.area == area && x.dt_start > DateTime.Now).dt_start.ToString();
                }
                catch (Exception)
                {

                    return;
                }
            }));

        }

        private void shutdownSchedule_Elaspsed(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (area == null) { return; }

                try
                {
                    DateTime dtStart = lsData.OrderBy(x => x.dt_start).First(x => x.area == area && x.dt_start > DateTime.Now).dt_start;

                    int warn_interval = 10;
                    switch (warnInterval.Text)
                    {
                        case "1 minute before":
                            warn_interval = 1;
                            break;
                        case "5 minutes before":
                            warn_interval = 5;
                            break;
                        case "10 minutes before":
                            warn_interval = 10;
                            break;
                        case "15 minutes before":
                            warn_interval = 15;
                            break;
                        default:
                            warn_interval = 10;
                            break;
                    }

                    if (DateTime.Now.AddMinutes(warn_interval) > dtStart)
                    {
                        if (action == "Shutdown")
                        {
                            string shutdown_string = (warn_interval * 60).ToString();
                            // do the shutdown now.
                            Process.Start("shutdown", "/s /t " + shutdown_string);

                            shutdownSchedule.Stop();
                        }

                        if (action == "Warning")
                        {
                            MessageBox.Show("Loadshedding in " + warn_interval + " minute!!!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                            shutdownSchedule.Stop();
                        }
                    }
                }
                catch (Exception e)
                {
                    return;
                }

            }));

        }

        private void get_areas()
        {
            // Get only the areas
            List<string> areaList = lsData.Select(x => x.area).Distinct().ToList();

            // Convert it to a comboBox friendly format
            string[] comboAreaList = areaList.ToArray();

            areaComboBox.Items.Clear();

            areaComboBox.Items.AddRange(comboAreaList);


        }

        private async Task get_loadshedding_schedule()
        {
            string url = "https://ripkk.0x.no/parser.php";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (lsData != null)
            {
                lsData.Clear();
            }


            lsData = JsonSerializer.Deserialize<List<LoadSheddingData>>(jsonResponse);

            if (init == false)
            {
                get_areas();

                init = true;
            }
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                area = areaComboBox.Text; statusLabel.Text = lsData.OrderBy(x => x.dt_start).First(x => x.area == area && x.dt_start > DateTime.Now).stage;
                nextLabel.Text = lsData.OrderBy(x => x.dt_start).First(x => x.area == area && x.dt_start > DateTime.Now).dt_start.ToString();
            }
            catch (Exception)
            {

                return;
            }

        }

        private void actionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            action = actionDropdown.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Rootobject
    {
        public LoadSheddingData[] Property1 { get; set; }
    }

    public class LoadSheddingData
    {
        public string area { get; set; }
        public string stage { get; set; }
        public DateTime dt_start { get; set; }
        public DateTime dt_end { get; set; }
    }
}