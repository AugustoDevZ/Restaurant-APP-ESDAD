
using NAudio.Wave;
using System.Windows.Threading;
using Vosk;
using ZadintsApp.UI.Views;
using Zrutas.Config;
using static System.Net.Mime.MediaTypeNames;


namespace Zrutas.Utils.NodoManager
{
    public class AudioManager: AppSetting
    {
        private WaveInEvent waveIn;

        private VoskRecognizer recognizer;
        private Model model;

        private Dashboard _dashboard;

        public AudioManager(Dashboard dashboard)
        {
            _dashboard = dashboard;

            string modelPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Models",
                "vosk-model-small-es-0.42"
            );

            model = new Model(modelPath);
        }

        public void StartRecording()
        {
            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(16000, 1)
            };

            recognizer = new VoskRecognizer(model, 16000.0f);

            waveIn.DataAvailable += (s, e) =>
            {
                if (recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded))
                {
                    string json = recognizer.Result();

                    var text = System.Text.Json.JsonDocument
                        .Parse(json)
                        .RootElement
                        .GetProperty("text")
                        .GetString();

                    _dashboard.Dispatcher.Invoke(() =>
                    {
                        _dashboard.txtBuscador.Text = text;
                    });
                }
                else
                {
                    string json = recognizer.PartialResult();

                    var text = System.Text.Json.JsonDocument
                        .Parse(json)
                        .RootElement
                        .GetProperty("partial")
                        .GetString();

                    _dashboard.Dispatcher.Invoke(() =>
                    {
                        _dashboard.txtBuscador.Text = text;
                    });
                }
            };

            waveIn.StartRecording();
        }

        public void StopRecording()
        {
            waveIn?.StopRecording();
            waveIn?.Dispose();

            recognizer?.Dispose();
        }
    }
}
