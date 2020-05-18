
import 'ol/ol.css';
import Map from 'ol/Map';
import Overlay from 'o



l / Overlay';
import View from 'ol/View';
import { toStringHDMS } from 'ol/coordinate';
import TileLayer from 'ol/layer/Tile';
import { toLonLat } from 'ol/proj';
import TileJSON from 'ol/source/TileJSON';

var key = 'Your Mapbox access token from https://mapbox.com/ here';

/**
 * Elements that make up the popup.
 */
var container = document.getElementById('popup');
var content = document.getElementById('popup-content');
var closer = document.getElementById('popup-closer');


/**
 * Create an overlay to anchor the popup to the map.
 */
var overlay = new Overlay({
    element: container,
    autoPan: true,
    autoPanAnimation: {
        duration: 250
    }
});


/**
 * Add a click handler to hide the popup.
 * @return {boolean} Don't follow the href.
 */
closer.onclick = function () {
    overlay.setPosition(undefined);
    closer.blur();
    return false;
};


/**
 * Create the map.
 */
var map = new Map({
    layers: [
        new TileLayer({
            source: new TileJSON({
                url: 'https://api.tiles.mapbox.com/v4/mapbox.natural-earth-hypso-bathy.json?access_token=' + key,
                crossOrigin: 'anonymous'
            })
        })
    ],
    overlays: [overlay],
    target: 'map',
    view: new View({
        center: [0, 0],
        zoom: 2
    })
});


/**
 * Add a click handler to the map to render the popup.
 */
map.on('singleclick', function (evt) {
    var coordinate = evt.coordinate;
    var hdms = toStringHDMS(toLonLat(coordinate));

    content.innerHTML = '<p>You clicked here:</p><code>' + hdms +
        '</code>';
    overlay.setPosition(coordinate);
});