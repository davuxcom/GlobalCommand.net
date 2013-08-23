using System;
using System.Collections.Generic;
using System.Text;
using GCPluginFramework;
using System.Xml.Serialization;


[Plugin(PluginType.Default)]
public class iTunesPlugin : IGCPlugin
{


    private iTunesLib.iTunesApp it;

    public iTunesPlugin() {
        System.Threading.Thread t = new System.Threading.Thread(Start_iTunes);
        t.Start();
    }

    public void Start_iTunes()
    {
        try
        {

            it = new iTunesLib.iTunesApp();
        }
        catch (Exception)
        {
            //throw new Exception("iTunes not installed");
        }
    }

    


    public bool ShowConfigDialog()
    {
        return false;
    }

    public override string ToString()
    {
        return FriendlyName;
    }

    public gcCommand[] getCommands()
    {
        List<gcCommand> li = new List<gcCommand>();

        li.Add(new gcCommand("Artist of the media currently playing in iTunes", "Artist"));
        li.Add(new gcCommand("Title of the media currently playing in iTunes", "Title"));
        li.Add(new gcCommand("Album of the media currently playing in iTunes", "Album"));
        li.Add(new gcCommand("BitRate of the media currently playing in iTunes", "BitRate"));
        li.Add(new gcCommand("Beats Per Minute of the media currently playing in iTunes", "BPM"));
        li.Add(new gcCommand("Composer of the media currently playing in iTunes", "Composer"));
        li.Add(new gcCommand("Duration of the media currently playing in iTunes", "Duration"));
        li.Add(new gcCommand("Genre of the media currently playing in iTunes", "Genre"));
        li.Add(new gcCommand("Number of times that the media currently playing in iTunes has been played", "PlayedCount"));
        li.Add(new gcCommand("Rating of the media currently playing in iTunes", "Rating"));
        li.Add(new gcCommand("SampleRate of the media currently playing in iTunes", "SampleRate"));
        li.Add(new gcCommand("Elapsed Time of the media currently playing in iTunes", "ElapsedTime"));
        li.Add(new gcCommand("Track number of the media currently playing in iTunes", "TrackNum"));
        li.Add(new gcCommand("Year that the media currently playing in iTunes was created", "Year"));

        li.Add(new gcCommand("Play or Pause iTunes", "PlayPause"));
        li.Add(new gcCommand("Advance to the next track in iTunes", "NextTrack"));
        li.Add(new gcCommand("Go back to the previous track in iTunes", "PrevTrack"));
        li.Add(new gcCommand("Stop the currently playing media in iTunes", "Stop"));
        li.Add(new gcCommand("Play the currently loaded media in iTunes", "Play"));
        li.Add(new gcCommand("Quit iTunes", "Quit"));    
        
        return li.ToArray();
    }

    public string ExecuteCommand(string cmd, string args)
    {
        try
        {
            switch (cmd.ToLower())
            {

                // values

                case "artist":
                    return it.CurrentTrack.Artist;
                case "title":
                    return it.CurrentTrack.Name;
                case "album":
                    return it.CurrentTrack.Album;
                case "bitrate":
                    return Convert.ToString(it.CurrentTrack.BitRate);
                case "bpm":
                    return Convert.ToString(it.CurrentTrack.BPM);
                case "composer":
                    return it.CurrentTrack.Composer;
                case "elapsedtime":
                    int p = it.PlayerPosition;
                    if (p % 60 < 10)
                    {
                        return (p / 60) + ":0" + (p % 60);
                    }
                    else
                    {
                        return (p / 60) + ":" + (p % 60);
                    }
                case "genre":
                    return it.CurrentTrack.Genre;
                case "playedcount":
                    return Convert.ToString(it.CurrentTrack.PlayedCount);
                case "rating":
                    return Convert.ToString(it.CurrentTrack.Rating);
                case "samplerate":
                    return Convert.ToString(it.CurrentTrack.SampleRate);
                case "duration":
                    return it.CurrentTrack.Time;
                case "#":
                    return Convert.ToString(it.CurrentTrack.TrackNumber);
                case "year":
                    return Convert.ToString(it.CurrentTrack.Year);

                // actions

                case "playpause":
                    it.PlayPause();
                    break;
                case "stop":
                    it.Stop();
                    break;
                case "nexttrack":
                    it.NextTrack();
                    break;
                case "prevtrack":
                    it.PreviousTrack();
                    break;
                case "quit":
                    it.Quit();
                    break;
                case "play":
                    it.Play();
                    break;
                default:
                    break;

            }
            return "";
        }
        catch (NullReferenceException)
        {
            return "Not Loaded";
        }
        catch (Exception)
        {
            System.Threading.Thread.Sleep(100);
            // error - re-create itunes object
            it = new iTunesLib.iTunesApp();
            try
            {

                return ExecuteCommand(cmd,args);
            }
            catch (Exception exp)
            {
                // still won't work, spit out a message to the user, sorry.
                return exp.Message;
            }

            // itunes must now work, handle the request

        }
    }

    public string PreviewCommandOutput(string cmd, string args)
    {
        switch(cmd.ToLower().Trim()) {
            case "quit":
            case "play":
            case "playpause":
            case "stop":
            case "nexttrack":
            case "prevtrack":
                return "";
            default:
        return ExecuteCommand(cmd,args);
        }

    }



    public string Description
    {
        get { return "Control iTunes and get song information"; }
    }

    public string FriendlyName
    {
        get { return "iTunes Media Player"; }
    }

    public string ShortName
    {
        get { return "iTunes"; }
    }

    public void LoadSettings(string[] settings)
    {
        return;
    }

    public string[] SaveSettings()
    {
        return null;
    }

    public string Author
    {
        get
        {
            return "David Amenta";
        }
    }




};
