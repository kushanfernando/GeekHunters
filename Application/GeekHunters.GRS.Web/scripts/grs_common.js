function LoadCandidate()
{
    setLoadingVisibility("visible");

    $.ajax({
        type: "GET",
        url: "/Home/GetCandidatesView",
        success: function (data, textStatus) {
            $(".main-content").html(data);
        },
        error: function () {
            alert('Loading Error');
        }
    });

    setLoadingVisibility("hidden");
}

function LoadSkills()
{
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

function setLoadingVisibility(visibility)
{
    $(".loading").css("visibility", visibility);
}