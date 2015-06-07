var gulp = require( "gulp" ),
    tsc = require( "gulp-typescript" ),
    tslint = require( "gulp-tslint" ),
    sourcemaps = require( "gulp-sourcemaps" ),
    clean = require( "gulp-clean" ),
    typescript = require( "typescript" ),
    merge = require( "merge2" ),
    Config = require( "./gulpfile.config" ),
    inject = require( "gulp-inject" ),
    debug = require( "gulp-debug" ),
    tslint = require( "gulp-tslint" ),
    less = require( "gulp-less" ),
    LessPluginAutoPrefix = require( "less-plugin-autoprefix" ),
    autoprefix = new LessPluginAutoPrefix( { browsers: ["last 2 versions"] } );

var config = new Config();
var tsProj = tsc.createProject( {
    target: "ES5",
    noExternalResolve: true,
    typescript: typescript,
    declarationFiles: false,
    module: "commonjs",
    noImplicitAny: true,
    removeComments: true
} );
function logError( error ) {
    console.log( error );
    this.emit( 'end' );
};

gulp.task( 'gen-ts-refs', function() {
    var target = gulp.src( config.appTypeDef );
    var sources = gulp.src( [config.allTs], { read: false } );
    return target.pipe( inject( sources, {
        starttag: "//{",
        endtag: "//}",
        transform: function( filepath ) {
            return "/// <reference path=\"../.." + filepath + "\" />";
        }
    } ) ).pipe( gulp.dest( config.tsTypings ) );
} );

gulp.task( "compile-ts", function() {
    var sourceTsFiles = [config.allTs, config.libTypeDefs];

    var tsResult = gulp.src( sourceTsFiles )
        .pipe( sourcemaps.init() )
        .pipe( tsc( tsProj ) );
    ;
    return merge( [
        tsResult.dts.pipe( gulp.dest( config.appTypeDef ) ),
        tsResult.js.pipe( sourcemaps.write( "." ) )
        .pipe( gulp.dest( config.jsApp ) )
    ] ); 
} );

gulp.task( "clean-ts", function() {
    var typeScriptGenFiles = [
        config.jsApp
    ];

    return gulp.src( typeScriptGenFiles, { read: false } )
        .pipe( clean() );
} );

gulp.task( 'ts-lint', function() {
    return gulp.src( config.allTs ).pipe( tslint() ).pipe( tslint.report( "verbose" ) );
} );

gulp.task( "less", function() {
    gulp.src( config.allLess )
        .on( "error", logError )
        //.pipe( sourcemaps.init() )
        .pipe( less( {
            plugins: [autoprefix]
        } ) )
        .on( "error", logError )
        //.pipe( less() )
        //.pipe( sourcemaps.write(".") )
        .pipe( gulp.dest( config.cssRoot ) )
        .on( "error", logError );
} );

gulp.task( "watch", function() {
    return gulp.watch( [config.allTs], ["ts-lint", "compile-ts", "gen-ts-refs"] );
} );

gulp.task( "watch-less", function() {
    return gulp.watch( [config.allLess], ["less"] );
} );

gulp.task( "clean", function() {
    var foldersToClean = [config.jsLib, config.jsApp];
    return gulp.src( foldersToClean, { read: false } )
        .pipe( clean() );
} );

gulp.task( "copy", ["clean"], function() {
    var bower = {
        "bootstrap": "/bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "jquery": "/jquery/dist/jquery*.{js,map}",
        "angular": "/angularjs/angular*.{js,map}",
        "require": "/requirejs/*.js"
    };

    for( var destDir in bower ) {
        if( bower.hasOwnProperty( destDir ) ) {
            gulp.src( config.bower + bower[destDir] )
                .pipe( gulp.dest( config.jsLib + "/" + destDir ) );
        }
    }
} );

gulp.task( "default", ["ts-lint", "compile-ts", "gen-ts-refs", "watch", "watch-less"] );