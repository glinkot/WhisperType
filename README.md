# WhisperType

Open source dictation UI for Whisper.net

Simple dictation UI for Winforms, using .NET implementation of OpenAI's Whisper thanks to [whisper.cpp](https://github.com/ggerganov/whisper.cpp) by GEorgi Geranov and [whisper.net] (https://github.com/sandrohanea/whisper.net) by Sandro Hanea

![First screenshot](ss1.png)

![Second screenshot](ss2.png)

## Getting Started
Open project in Visual Studio, update Nuget dependencies, compile and run.  

## Features
- Hotkey triggered start/stop of dictation, with dictation into WhisperType's window ready for editing
- Auto stop after voice activity stops (some configuration options are provided to improve accuracy depending on noise and other factors, ymmv).  Really, it's faster to hit the hotkey once, speak then hit the hotkey again.
- Transcription using local model (which is downloaded on demand using whisper.net's downloader) or via OpenAI API (you provide the key in config, it's stored locally at C:\Users\[USER]\AppData\Roaming\WhisperType\config.json)
- Logging of .wav and text versions of dictated content
- Keep WhisperType's interface always on top, or leave it in the tray and use the traffic light tray icon indicators to know when WT is recording or transcribing.

## Interface
[Screenshots/video pending]

## Using WhisperType
Two main usage methods are contemplated:
- Check 'type text in active window', put your cursor in desired app, and use ctrl-alt-space hotkey to start speaking.  Hit ctrl-alt-space again afterwards (or use auto stop on silence) and it will be typed in.
- Dictate multiple sentences into the WhisperType window, then copy your work to its destination

Generally 1-3 sentences are about the sweet spot, Whisper works best in snippets up to 30 seconds and uses context within that passage to maximise accuracy.  Saying just a few words seems to be a bit less accurate due to less context.  Recording > 30 seconds is fine, but I understand Whisper breaks the sound into 30 second portions for recognition.

## Inclusions
Includes the native x64 whisper.dll library from Whispercpp.

## Limitations
- Targets Windows x64 only
- Current implementation is 'one shot' dictation, though multiple individual utterances can be sequenced together and put in the target app in one go.  Use case is intended for short messages, slack notes etc.  A quick searching indicates possible accuracy loss with more continuous models due to the stitching of audio/text needed.
- CPU based local transcription; it is more than fast enough on my laptop but older computers may make typing (or using the API) look more attractive as an option!

## Potential improvements/plans (PR's welcome)
- Continuous dictation (next priority)
- Use of CUDA and other GPU methods for transcription.  The original whisper.net supports these targets, but creating a drop down selection at runtime wasn't cooperating for me.
- Cross platform
- Improve voice activity detection

## Maximising Local Performance
- Try the 'base' model and move up/down in size from there.  The smaller the model you can get good accuracy with, the better.
- Best recording conditions (decent microphone and low background noise) will get you best accuracy and may let you use a smaller model.
- Specify your language in config dialog to avoid the need for 'auto identifying' the language every time (performance impact unknown but must be non zero).
- If your PC just isn't fast enough, just use the API, it's cheap compared to a new computer!  

## Using existing downloaded models
- Run WhisperType once so its folders are created, then place your models in C:\Users\[USER]\AppData\Roaming\WhisperType\Models
- They should have filenames like this: ggml-base.bin

## Acknowledgements
- OpenAI Whisper - https://openai.com/research/whisper
- HuggingFace - https://huggingface.co/openai/whisper-large-v2
- Whispercpp - https://github.com/ggerganov/whisper.cpp
- Whisper.net - https://github.com/sandrohanea/whisper.net
- Icons8 - https://icons8.com/