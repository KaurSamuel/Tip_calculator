using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Tip_calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView Tip_toolbar;
        SeekBar Tip_seekbar;
        TextView Result_textBox;
        TextView bill_edit_text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            bill_edit_text = FindViewById<EditText>(Resource.Id.Bill_editText);
            Tip_seekbar = FindViewById<SeekBar>(Resource.Id.Tip_seek_bar);
            Result_textBox = FindViewById<TextView>(Resource.Id.Result_text_box);
            Tip_toolbar = FindViewById<TextView>(Resource.Id.Tip_toolbar);
            Button Uptate_putton = FindViewById<Button>(Resource.Id.Uptate_button);
            Uptate_putton.Click += delegate
            {
                Button_press();
            };
            Tip_seekbar.ProgressChanged += Tip_seekbar_ProgressChanged;
        }

        private void Tip_seekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {

            Tip_toolbar.Text = (e.Progress.ToString()+"%");
            int result = int.Parse(bill_edit_text.Text) * int.Parse(Tip_seekbar.Progress.ToString()) / 100;
            Result_textBox.Text = result.ToString();
        }
        private void Button_press ()
        {
            int result = int.Parse(bill_edit_text.Text) * int.Parse(Tip_seekbar.Progress.ToString()) / 100;
            Result_textBox.Text = result.ToString();
        }
    }
}