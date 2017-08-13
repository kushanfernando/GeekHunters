$(document).ready(function () {
    $("#menu").kendoMenu({
        select: function (e) {
            $.ajax({
                type: "GET",
                url: $(e.item).data('url'),
                success: function (data, textStatus) {
                    $(".main-content").html(data);
                    InitializeFilter();
                },
                error: function () {
                    alert('Loading Error');
                }
            });
        }
    });

    var registrationWindow = $(".candidate-register-window");
    
    registrationWindow.kendoWindow({
        width: "600px",
        title: "Register Candidate",
        visible: false,
        actions: [
            "Close"
        ],
        activate: function()
        {
            $("#firstName").focus();
        },
        close: function ()
        {
        }
    }).data("kendoWindow");

    var validator = $("#candidate-reg-form").kendoValidator().data("kendoValidator");

    $(".candidate-register-cancelbtn").click(function ()
    {
        registrationWindow.data("kendoWindow").close();
    });

    $(".candidate-register-registerbtn").click(function (e) {

        e.preventDefault();

        var selectedSkillIdCollection = [];
        $(".candidate-skill-btn.k-primary").each(function () {
            selectedSkillIdCollection.push($(this).attr("data-id"));
        });

        if (validator.validate()) {

            $.ajax({
                type: "POST",
                url: "/Home/RegisterCandidate",
                data: {
                    firstName: $("#firstName").val(),
                    lastName: $("#lastName").val(),
                    skillsCollection: selectedSkillIdCollection,
                },
                success: function (data, textStatus) {
                    
                    $("#firstName").val('');
                    $("#lastName").val('');
                    $(".candidate-skill-btn").removeClass("k-primary");

                    registrationWindow.data("kendoWindow").close();

                    LoadCandidate([]);
                },
                error: function () {
                    alert('Loading Error');
                }
            });
        }
    });

    $(".btn-registercandidate").click(function () {
        registrationWindow.data("kendoWindow").center().open();
    });

    $(".candidate-skill-btn").click(function (e) {
        e.preventDefault();
        $(this).toggleClass("k-primary").blur();
    });

    InitializeFilter();
});


function LoadCandidate(selectedSkillIdCollection) {
    $.ajax({
        type: "POST",
        url: "/Home/GetCandidateListView",
        data: { skillIdCollection: selectedSkillIdCollection },
        success: function (data, textStatus) {
            $("#candidateListView").html(data);
        },
        error: function () {
            alert('Loading Error');
        }
    });
}

function InitializeFilter() {

    $("#toolbar").kendoToolBar();
    var skillsCollection = $("#skillsCollection").kendoMultiSelect().data("kendoMultiSelect");

    $(".filter-candidate-btn").click(function () {

        LoadCandidate(skillsCollection.value());
    });
}



function LoadSkills() {
    setLoadingVisibility("visible");

    $.ajax({
        type: "GET",
        url: "/Home/GetSkillsView",
        success: function (data, textStatus) {
            $(".main-content").html(data);
        },
        error: function () {
            alert('Loading Error');
        }
    });

    setLoadingVisibility("hidden");
}

function setLoadingVisibility(visibility) {
    $(".loading").css("visibility", visibility);
}