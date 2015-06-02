/// <reference path="../../Tools/Typings/tsd.d.ts" />

module Dota2App.Controllers {
    import IHttpPromiseCallbackArg = ng.IHttpPromiseCallbackArg;
    import IHttpService = angular.IHttpService;
    import IScope = angular.IScope;

    export interface IDotaHero {
        LocalizedName: string;
        ImagePathSmallHorizontalPortrait: string;
    }

    export class TestController {
        name: string;
        heroes: IDotaHero[];

        static $inject = [
            "$scope",
            "$http"
        ];

        constructor( private $scope: IScope, private $http: IHttpService ) {
            this.name = "sdsd";

            $http.get("/api/Dota2Heroes").then((result: IHttpPromiseCallbackArg<IDotaHero[]>) => {
                this.activate( result.data );
            } );
        }

        activate = (heroes: IDotaHero[]) => {
            this.heroes = heroes;
        };
    }
}