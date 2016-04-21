
//bgSelector = '#background';
$(document).ready(function () {
    updateMusicInformation();
    window.setInterval(updateMusicInformation, 30000);
});

function updateMusicInformation() {
    getTracks(function (data) {
        $(".music-information").html(data);
    });
}

function getTracks(callback) {
    var userid = "AnalogIO";
    var lastfmApiKey = "34454ca3b453842c6bb875768a7d238c";
    var getTracksUrl = "http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=" + userid + "&api_key=" + lastfmApiKey;

    $.get(getTracksUrl,
      {
          format: "json"
      },
      function (data) {

          // If the data object doesn't have any tracks, return false
          if (!data.recenttracks.track[0]) {
              callback("");
              return;
          }

          var mostRecentSong = data.recenttracks.track[0];
          var nowplaying = mostRecentSong["@attr"] && mostRecentSong["@attr"].nowplaying;

          var artist = mostRecentSong.artist["#text"];
          var title = mostRecentSong.name;

          if (nowplaying) {
              // Return the HTML code to display
              var html = "<small>We're listening to <em>" + title + "</em> by <em>" + artist + "</em>.</small>";
              callback(html);
          } else {
              // Return empty string and dont display any information on the website
              callback("");
          }
      });
}
