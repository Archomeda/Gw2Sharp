using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Gw2Sharp;
using Gw2Sharp.Models;
using Gw2Sharp.Mumble;
using Gw2Sharp.WebApi.V2.Models;

namespace MumbleLinkReader
{
    public partial class Form1 : Form
    {
        private readonly Gw2Client client = new Gw2Client();

        private Thread? apiThread;
        private Thread? mumbleLoopThread;
        private bool stopRequested;

        private readonly Queue<int> apiMapDownloadQueue = new Queue<int>();
        private readonly HashSet<int> apiMapDownloadBusy = new HashSet<int>();
        private readonly ConcurrentDictionary<int, Map> maps = new ConcurrentDictionary<int, Map>();
        private readonly ConcurrentDictionary<int, ContinentFloor> floors = new ConcurrentDictionary<int, ContinentFloor>();
        private readonly AutoResetEvent apiMapDownloadEvent = new AutoResetEvent(false);

        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.apiThread = new Thread(this.ApiLoopAsync);
            this.mumbleLoopThread = new Thread(this.MumbleLoop);

            this.apiThread.Start();
            this.mumbleLoopThread.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UpdateStatus("Shutting down");
            this.stopRequested = true;
            this.apiMapDownloadEvent.Set();
        }

        private void UpdateStatus(string? message)
        {
            this.labelStatus.Invoke(new Action<string>(m =>
            {
                this.labelStatus.Text = m;
                this.labelStatus.Visible = !string.IsNullOrWhiteSpace(m);
            }), message);
        }


        private async void ApiLoopAsync()
        {
            while (!this.stopRequested)
            {
                this.apiMapDownloadEvent.WaitOne();
                if (this.stopRequested)
                    break;

                int mapId = this.apiMapDownloadQueue.Dequeue();
                this.UpdateStatus($"Downloading API information for map {mapId}");

                var map = await this.client.WebApi.V2.Maps.GetAsync(mapId);
                this.maps[mapId] = map;

                foreach (int floorId in map.Floors)
                {
                    if (!this.floors.ContainsKey(floorId))
                    {
                        this.UpdateStatus($"Downloading API information for floor {floorId}");
                        var floor = await this.client.WebApi.V2.Continents[map.ContinentId].Floors.GetAsync(floorId);
                        this.floors[floorId] = floor;
                    }
                }

                this.UpdateStatus(null);
            }
        }

        private void MumbleLoop()
        {
            do
            {
                bool shouldRun = true;
                this.client.Mumble.Update();
                if (!this.client.Mumble.IsAvailable)
                    shouldRun = false;

                int mapId = this.client.Mumble.MapId;
                if (mapId == 0)
                    shouldRun = false;

                if (shouldRun)
                {
                    if (!this.maps.ContainsKey(mapId) && !this.apiMapDownloadBusy.Contains(mapId))
                    {
                        this.apiMapDownloadBusy.Add(mapId);
                        this.apiMapDownloadQueue.Enqueue(mapId);
                        this.apiMapDownloadEvent.Set();
                    }

                    try
                    {
                        this.Invoke(new Action<IGw2MumbleClient>(m =>
                        {
                            this.textBoxVersion.Text = m.Version.ToString();
                            this.textBoxTick.Text = m.Tick.ToString();
                            this.textBoxAvatarPosition1.Text = m.AvatarPosition.X.ToString();
                            this.textBoxAvatarPosition2.Text = m.AvatarPosition.Y.ToString();
                            this.textBoxAvatarPosition3.Text = m.AvatarPosition.Z.ToString();
                            this.textBoxAvatarFront1.Text = m.AvatarFront.X.ToString();
                            this.textBoxAvatarFront2.Text = m.AvatarFront.Y.ToString();
                            this.textBoxAvatarFront3.Text = m.AvatarFront.Z.ToString();
                            this.textBoxName.Text = m.Name;
                            this.textBoxCameraPosition1.Text = m.CameraPosition.X.ToString();
                            this.textBoxCameraPosition2.Text = m.CameraPosition.Y.ToString();
                            this.textBoxCameraPosition3.Text = m.CameraPosition.Z.ToString();
                            this.textBoxCameraFront1.Text = m.CameraFront.X.ToString();
                            this.textBoxCameraFront2.Text = m.CameraFront.Y.ToString();
                            this.textBoxCameraFront3.Text = m.CameraFront.Z.ToString();

                            this.textBoxRawIdentity.Text = m.RawIdentity;
                            this.textBoxCharacterName.Text = m.CharacterName;
                            this.textBoxRace.Text = m.Race.ToString();
                            this.textBoxSpecialization.Text = m.Specialization.ToString();
                            this.textBoxTeamColorId.Text = m.TeamColorId.ToString();
                            this.checkBoxCommander.Checked = m.IsCommander;
                            this.textBoxFieldOfView.Text = m.FieldOfView.ToString();
                            this.textBoxUiSize.Text = m.UiSize.ToString();

                            this.textBoxServerAddress.Text = $"{m.ServerAddress}:{m.ServerPort}";
                            this.textBoxMapId.Text = m.MapId.ToString();
                            this.textBoxMapType.Text = m.MapType.ToString();
                            this.textBoxShardId.Text = m.ShardId.ToString();
                            this.textBoxInstance.Text = m.Instance.ToString();
                            this.textBoxBuildId.Text = m.BuildId.ToString();
                            this.checkBoxUiStateMapOpen.Checked = m.IsMapOpen;
                            this.checkBoxUiStateCompassTopRight.Checked = m.IsCompassTopRight;
                            this.checkBoxUiStateCompassRotationEnabled.Checked = m.IsCompassRotationEnabled;
                            this.checkBoxUiStateGameFocus.Checked = m.DoesGameHaveFocus;
                            this.checkBoxUiStateCompetitive.Checked = m.IsCompetitiveMode;
                            this.checkBoxUiStateInputFocus.Checked = m.DoesAnyInputHaveFocus;
                            this.textBoxCompassWidth.Text = m.Compass.Width.ToString();
                            this.textBoxCompassHeight.Text = m.Compass.Height.ToString();
                            this.textBoxCompassRotation.Text = m.CompassRotation.ToString();
                            this.textBoxPlayerCoordsX.Text = m.PlayerLocationMap.X.ToString();
                            this.textBoxPlayerCoordsY.Text = m.PlayerLocationMap.Y.ToString();
                            this.textBoxMapCenterX.Text = m.MapCenter.X.ToString();
                            this.textBoxMapCenterY.Text = m.MapCenter.Y.ToString();
                            this.textBoxMapScale.Text = m.MapScale.ToString();

                            if (this.maps.TryGetValue(m.MapId, out var map))
                            {
                                this.textBoxMapName.Text = map.Name;

                                var mapPosition = m.AvatarPosition.ToMapCoords(CoordsUnit.Mumble);
                                this.textBoxMapPosition1.Text = mapPosition.X.ToString();
                                this.textBoxMapPosition2.Text = mapPosition.Y.ToString();
                                this.textBoxMapPosition3.Text = mapPosition.Z.ToString();

                                var continentPosition = m.AvatarPosition.ToContinentCoords(CoordsUnit.Mumble, map.MapRect, map.ContinentRect);
                                this.textBoxContinentPosition1.Text = continentPosition.X.ToString();
                                this.textBoxContinentPosition2.Text = continentPosition.Y.ToString();
                                this.textBoxContinentPosition3.Text = continentPosition.Z.ToString();

                                ContinentFloorRegionMapPoi? closestWaypoint = null;
                                Coordinates2 closestWaypointPosition = default;
                                double closestWaypointDistance = double.MaxValue;
                                ContinentFloorRegionMapPoi? closestPoi = null;
                                Coordinates2 closestPoiPosition = default;
                                double closestPoiDistance = double.MaxValue;
                                foreach (int floorId in map.Floors)
                                {
                                    if (this.floors.TryGetValue(floorId, out var floor))
                                    {
                                        if (floor.Regions.TryGetValue(map.RegionId, out var floorRegion))
                                        {
                                            if (floorRegion.Maps.TryGetValue(map.Id, out var floorMap))
                                            {
                                                foreach (var poi in floorMap.PointsOfInterest)
                                                {
                                                    double distanceX = Math.Abs(continentPosition.X - poi.Value.Coord.X);
                                                    double distanceZ = Math.Abs(continentPosition.Z - poi.Value.Coord.Y);
                                                    double distance = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceZ, 2));
                                                    if (poi.Value.Type.Value == PoiType.Waypoint && distance < closestWaypointDistance)
                                                    {
                                                        closestWaypointPosition = poi.Value.Coord;
                                                        closestWaypointDistance = distance;
                                                        closestWaypoint = poi.Value;
                                                    }
                                                    else if (poi.Value.Type.Value == PoiType.Landmark && distance < closestPoiDistance)
                                                    {
                                                        closestPoiPosition = poi.Value.Coord;
                                                        closestPoiDistance = distance;
                                                        closestPoi = poi.Value;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (closestWaypoint != null)
                                {
                                    this.textBoxWaypoint.Text = closestWaypoint.Name;
                                    int poiId = closestWaypoint.Id;
                                    this.textBoxWaypointLink.Text = closestWaypoint.ChatLink;
                                    this.textBoxWaypointContinentDistance.Text = closestWaypointDistance.ToString();
                                    this.textBoxWaypointContinentPosition1.Text = closestWaypoint.Coord.X.ToString();
                                    this.textBoxWaypointContinentPosition2.Text = closestWaypoint.Coord.Y.ToString();
                                    double angle = Math.Atan2(continentPosition.Z - closestWaypointPosition.Y, continentPosition.X - closestWaypointPosition.X) * 180 / Math.PI;
                                    this.textBoxWaypointDirection1.Text = this.GetDirectionFromAngle(angle).ToString();
                                    this.textBoxWaypointDirection2.Text = angle.ToString();
                                }
                                else
                                {
                                    this.textBoxWaypoint.Text = string.Empty;
                                    this.textBoxWaypointLink.Text = string.Empty;
                                    this.textBoxWaypointContinentDistance.Text = string.Empty;
                                    this.textBoxWaypointContinentPosition1.Text = string.Empty;
                                    this.textBoxWaypointContinentPosition2.Text = string.Empty;
                                    this.textBoxWaypointDirection1.Text = string.Empty;
                                    this.textBoxWaypointDirection2.Text = string.Empty;
                                }

                                if (closestPoi != null)
                                {
                                    this.textBoxPoi.Text = closestPoi.Name;
                                    int poiId = closestPoi.Id;
                                    this.textBoxPoiLink.Text = closestPoi.ChatLink;
                                    this.textBoxPoiContinentDistance.Text = closestPoiDistance.ToString();
                                    this.textBoxPoiContinentPosition1.Text = closestPoi.Coord.X.ToString();
                                    this.textBoxPoiContinentPosition2.Text = closestPoi.Coord.Y.ToString();
                                    double angle = Math.Atan2(continentPosition.Z - closestPoiPosition.Y, continentPosition.X - closestPoiPosition.X) * 180 / Math.PI;
                                    this.textBoxPoiDirection1.Text = this.GetDirectionFromAngle(angle).ToString();
                                    this.textBoxPoiDirection2.Text = angle.ToString();
                                }
                                else
                                {
                                    this.textBoxPoi.Text = string.Empty;
                                    this.textBoxPoiLink.Text = string.Empty;
                                    this.textBoxPoiContinentDistance.Text = string.Empty;
                                    this.textBoxPoiContinentPosition1.Text = string.Empty;
                                    this.textBoxPoiContinentPosition2.Text = string.Empty;
                                    this.textBoxPoiDirection1.Text = string.Empty;
                                    this.textBoxPoiDirection2.Text = string.Empty;
                                }
                            }
                        }), this.client.Mumble);
                    }
                    catch (ObjectDisposedException)
                    {
                        // The application is likely closing
                        break;
                    }
                }

                Thread.Sleep(1000 / 60);
            } while (!this.stopRequested);
        }

        private Direction GetDirectionFromAngle(double angle)
        {
            if (angle < -168.75)
                return Direction.West;
            else if (angle < -146.25)
                return Direction.WestNorthWest;
            else if (angle < -123.75)
                return Direction.NorthWest;
            else if (angle < -101.25)
                return Direction.NorthNorthWest;
            else if (angle < -78.75)
                return Direction.North;
            else if (angle < -56.25)
                return Direction.NorthNorthEast;
            else if (angle < -33.75)
                return Direction.NorthEast;
            else if (angle < -11.25)
                return Direction.EastNorthEast;
            else if (angle < 11.25)
                return Direction.East;
            else if (angle < 33.75)
                return Direction.EastSouthEast;
            else if (angle < 56.25)
                return Direction.SouthEast;
            else if (angle < 78.78)
                return Direction.SouthSouthEast;
            else if (angle < 101.25)
                return Direction.South;
            else if (angle < 123.75)
                return Direction.SouthSouthWest;
            else if (angle < 146.25)
                return Direction.SouthWest;
            else if (angle < 168.75)
                return Direction.WestSouthWest;
            else
                return Direction.West;
        }

        private enum Direction
        {
            North,
            NorthNorthEast,
            NorthEast,
            EastNorthEast,
            East,
            EastSouthEast,
            SouthEast,
            SouthSouthEast,
            South,
            SouthSouthWest,
            SouthWest,
            WestSouthWest,
            West,
            WestNorthWest,
            NorthWest,
            NorthNorthWest
        }
    }
}
