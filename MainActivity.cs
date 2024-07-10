namespace AndroidSentry;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetContentView(Resource.Layout.activity_main);
        FindViewById<Button>(Resource.Id.button).Click += (sender, args) => SentrySdk.CauseCrash(CrashType.Native);

        SentrySdk.Init(options =>
        {
            options.Dsn = "https://eb18e953812b41c3aeb042e666fd3b5c@o447951.ingest.sentry.io/5428537";
            options.Native.EnableBeforeSend = true;
            options.SetBeforeSend(@event => @event);
        });
    }
}