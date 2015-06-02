require.config( {
    //By default load any module IDs from js/lib
    baseUrl: "app/",
    //except, if the module ID starts with "app",
    //load it from the js/app directory. paths
    //config is relative to the baseUrl, and
    //never includes a ".js" extension since
    //the paths config could be for a directory.
    paths: {
        lib: "../lib",
    }
} );

requirejs( ["lib/angular/angular"], function() {
    require( ["app"], function() {
        angular.element( document ).ready( function() {
            angular.bootstrap( document, ['dotaApp'] );
        } );
    } );
} );