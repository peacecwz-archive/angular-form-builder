var isLoaded = false;
var baseUrl = 'http://localhost:51468/';
var baseApiUrl = 'http://localhost:50730/api/v1';
var config = {
    headers: {
        'Content-Type': 'application/json'
    }
}
angular
    .module("app", ["ngRoute", "builder", "builder.components", "validator.rules"])
    .config([
        '$routeProvider', '$routeProvider', function ($routeProvider, $routeProvider) {
            $routeProvider
                .when('/create',
                {
                    controller: 'CreateFormController',
                    templateUrl: 'forms/create'
                })
                .when('/display/:id',
                {
                    controller: 'FormController',
                    templateUrl: 'forms/index'
                })
                .when('/answers/:key',
                {
                    controller: 'FormAnswersController',
                    templateUrl: 'Forms/GetAnswers'
                }).otherwise({
                    redirectTo: '/create'
                });
        }
    ])
    .run()
    .controller("FormController",
    [
        '$scope', '$builder', '$validator', '$http', '$routeParams',
        function ($scope, $builder, $validator, $http, $routeParams) {
            $scope.input = [];
            $scope.formName = "Form";
            $scope.title = $scope.formName; 
            $http.get(baseApiUrl + "/forms/get/" + $routeParams.id)
                .then(function (response) {
                    var data = response.data;
                    var items = JSON.parse(data.result.formSchema);
                    $scope.formName = data.result.name;
                    if ($builder.forms["default"].length !== items.length) {
                        for (var i = 0; i < items.length; i++) {
                            $builder.addFormObject("default", items[i]);
                        }
                    }
                });

            return ($scope.submit = function () {
                return $validator
                    .validate($scope, "default")
                    .success(function () {
                        $http.post(baseApiUrl + "/forms/answer",
                            {
                                Answer: JSON.stringify($scope.input),
                                FormId: $routeParams.id
                            }).then(function (response) {
                                console.log(response);
                                alert("Sent your form successfully");
                            });
                        return console.log("success");
                    })
                    .error(function () {
                        return console.log("error");
                    });
            });
        }
    ])
    .controller("CreateFormController",
    [
        "$scope",
        "$builder",
        "$validator",
        '$http',
        '$location',
        function ($scope, $builder, $validator, $http, $location) {
            $scope.form = $builder.forms["default"];
            $scope.input = [];
            $scope.defaultValue = {};
            $scope.formUrl = '';
            $scope.answerUrl = '';
            $scope.isSuccess = false;
            $scope.formName = '';

            $scope.createForm = function () {
                $http.post(baseApiUrl + '/forms/create',
                    {
                        FormName: $scope.formName,
                        FormSchema: JSON.stringify($scope.form)
                    },
                    config).then(function (response) {
                        var data = response.data;
                        $scope.isSuccess = data.isSuccess;
                        $scope.formUrl = baseUrl + '#!/display/' + data.result.id;
                        $scope.answerListUrl = baseUrl + '#!/answers/' + data.result.key;
                    }).then(function (err) {
                        console.log(err)
                    });
            };

            $scope.addComponent = function (type) {
                switch (type) {
                    case "input":
                        $builder.addFormObject("default",
                            {
                                component: "textInput",
                                editable: true,
                                id: "textInput",
                                label: "Text Input",
                                description: "description",
                                placeholder: "placeholder",
                                options: [],
                                required: false,
                                validation: "/.*/"
                            });
                        break;
                    case "textarea":
                        $builder.addFormObject("default",
                            {
                                id: "textarea",
                                component: "textArea",
                                label: "Name",
                                description: "Your name",
                                placeholder: "Your name",
                                required: true,
                                editable: false
                            });
                        break;
                    case "checkbox":
                        $builder.addFormObject("default",
                            {
                                id: "checkbox",
                                component: "checkbox",
                                label: "Pets",
                                description: "Do you have any pets?",
                                options: ["Dog", "Cat"]
                            });
                        break;
                    case "radio":
                        $builder.addFormObject("default",
                            {
                                id: "radio",
                                component: "radio",
                                label: "Pets",
                                description: "Do you have any pets?",
                                options: ["Dog", "Cat"]
                            });
                        break;
                    case "select":
                        $builder.addFormObject("default",
                            {
                                id: "select",
                                component: "select",
                                label: "Pets",
                                description: "Do you have any pets?",
                                options: ["Dog", "Cat"]
                            });
                        break;
                    default:
                        $builder.addFormObject("default",
                            {
                                id: "textbox",
                                component: "textInput",
                                label: "Name",
                                description: "Your name",
                                placeholder: "Your name",
                                required: true,
                                editable: false
                            });
                        break;
                }
            };

        }
    ])
    .controller("FormAnswersController",
    [
        '$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
            $scope.answers = [];
            $scope.columns = [];
            $http.get(baseApiUrl + "/forms/getanswers/" + $routeParams.key)
                .then(function (response) {
                    var answers = response.data.result;
                    for (var i = 0; i < answers.length; i++) {
                        $scope.answers.push(JSON.parse(answers[i].answer));
                    }
                    if ($scope.answers.length > 0) {
                        $scope.columns = $scope.answers[0];
                    }
                });
        }
    ]);