using Android.App;
using Android.Widget;
using Android.OS;

namespace ManagedBass.Sample.Android
{
    [Activity (Label = "ManagedBass.Sample.Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        readonly SineWave _sineWave = new SineWave(20, 20, 40, 100);

        protected override void OnCreate (Bundle SavedInstanceState)
        {
            base.OnCreate (SavedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var controller = FindViewById<Button>(Resource.Id.controller);

            controller.Click += (sender, e) =>
            {
                if (Bass.ChannelIsActive(_sineWave.Handle) == PlaybackState.Playing)
                {
                    Bass.ChannelStop(_sineWave.Handle);

                    controller.Text = "Start SineWave";
                }
                else
                {
                    Bass.ChannelPlay(_sineWave.Handle);

                    controller.Text = "Stop";
                }
            };
        }
    }
}
