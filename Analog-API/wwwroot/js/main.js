
//bgSelector = '#background';
$(document).ready(function() {
  getTracks(function(data){
    $('.music-information').html(data);
  });

});


//$(document).ready(function() {
//	fixBackgroundPlacement();
//});

//$(window).resize(function() {
//	fixBackgroundPlacement();
//});

function fixBackgroundPlacement() {
	var winHeight = jQuery(window).height();
	var winWidth = jQuery(window).width();

	var bgHeight = jQuery(bgSelector).outerHeight(true);
	var bgWidth = jQuery(bgSelector).outerWidth(true);

	//Expand background image to fill screen, if needed
	if ((winWidth / winHeight) > (bgWidth / bgHeight))
	{
		jQuery(bgSelector).css('width', winWidth);
		jQuery(bgSelector).css('height', 'auto');
	}
	else
	{
		jQuery(bgSelector).css('height', winHeight);
		jQuery(bgSelector).css('width', 'auto');
	}

	//Center background image vertically, if needed
	var verticalOffset = (bgHeight - winHeight);
	if (verticalOffset > 0)
	{
		jQuery(bgSelector).css('top', -(verticalOffset/2));
	}


	//Center background image horizontally, if needed
	var horizontalOffset = (bgWidth - winWidth);
	if (horizontalOffset > 0)
	{
		jQuery(bgSelector).css('left', -(horizontalOffset/2));
	}
}
function getTracks (callback) {
  var userid = 'AnalogIO';
  var lastfm_api_key = '34454ca3b453842c6bb875768a7d238c';
  var get_tracks_url = 'http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=' + userid + '&api_key=' + lastfm_api_key;

   $.get(get_tracks_url,
     {
       format: 'json'
     },
     function(data){

      // If the data object doesn't have any tracks, return false
      if (!data.recenttracks.track[0]) {
        callback('');
        return;
      }

       var mostRecentSong = data.recenttracks.track[0];
       if(mostRecentSong["@attr"] && mostRecentSong["@attr"].nowplaying){
        var nowplaying = true;
       } else {
        var nowplaying = false;
       }

       var artist = mostRecentSong.artist["#text"];
       var title = mostRecentSong.name;

        if (nowplaying == true) {
          // Return the HTML code to display
          var html = '<small>We\'re listening to <em>'+ title + '</em> by <em>'+ artist + '</em>.</small>';
          callback(html);
        } else {
          // Return empty string and dont display any information on the website
          callback('');
        }
   });

}
