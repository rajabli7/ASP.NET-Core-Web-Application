$(document).ready(function () {
    $("select.service-type").change(function () {
        var serviceTypeId = $("select.service-type option:selected").val();
        $('.additions-content').load("/Services/ShowAdditionsForServiceType", { serviceTypeId: serviceTypeId });
        $(this).removeClass("error-border");
        $("div.service-type-msg").addClass("visibility-hidden");
        $("input.price").val($("select.service-type option:selected").attr("data-price"));
    });

    $("input.project-date").blur(function () {
        checkProjectDateField();
    });

    $("input.address").blur(function () {
        checkAddressField();
    });

    $("#order-form").submit(function (e) {
        e.preventDefault();

        if (checkFields()) {
            $.ajax({
                url: "/Orders/MakeOrders/",
                method: "POST",
                data: $('#order-form').serialize(),
                success: function () {
                    alert("Заказ отправлен");
                    window.location.href = "/Orders/MakeOrders/";
                }
            });
        }
    });

    function checkFields() {
        var header = $("select.service-type").removeClass("error-border");
        $("div.service-type-msg").addClass("visibility-hidden");

        var valid = true;
        if (String($("select.service-type option:selected").val()) == "0") {
            header.addClass("error-border");
            $("div.service-type-msg").removeClass("visibility-hidden");
            valid = false;
        }

        if (!checkAddressField()) {
            valid = false;
        }

        if (!checkProjectDateField()) {
            valid = false;
        }

        return valid;
    }

    function checkAddressField() {
        var address = $("input.address").removeClass("error-border");
        $("div.address-msg").addClass("visibility-hidden");

        if (String(address.val()).length == 0) {
            address.addClass("error-border");
            $("div.address-msg").removeClass("visibility-hidden");
            return false;
        }
        return true;
    }

    function checkProjectDateField() {
        var projectDate = $("input.project-date").removeClass("error-border");
        $("div.project-date-msg").addClass("visibility-hidden");

        var today = new Date();
        var date = new Date(projectDate.val());
        if (!(date instanceof Date) || isNaN(date)) {
            projectDate.addClass("error-border");
            $("div.project-date-msg").removeClass("visibility-hidden");
            return false;
        }
        if (today >= date) {
            projectDate.addClass("error-border");
            $("div.project-date-msg").removeClass("visibility-hidden");
            return false;
        }
        return true;
    }

    $(".delete-img").click(function () {
        var id = $(this).data("id");
        $.ajax({
            url: "/Services/Delete/",
            method: "POST",
            data: { id: id },
            success: function () {
                window.location.reload();
            }
        });
    });

    $(".photogallery-search").keyup(function () {
        var text = $(this).val();
        var searchValues = $(".search-value");
        searchValues.filter(".search-value").closest("tr").hide();
        searchValues.filter(function () {
            if ($(this).val().toLowerCase().includes(text.toLowerCase())) {
                $(this).closest("tr").show();
            }
        });
    });
});