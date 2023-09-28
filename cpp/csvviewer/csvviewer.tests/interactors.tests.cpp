#include <gmock/gmock.h>
#include "Interactors.h"

namespace csvviewer
{
    using namespace testing;
    using Row = std::vector<std::string>;
    std::ostream& operator<< (std::ostream& out, const Record& record) {
        out << '[';
        for(const auto& l : record.Values)
            out << l << ',';
        out << ']';
        return out;
    }
    class InteractorsTests : public Test {
    public:
        Interactors sut;
    };

    TEST_F(InteractorsTests, Start_with_necessary_parameters)
    {
        auto result = sut.Start({"persons.csv"});

        EXPECT_THAT(result, SizeIs(4));
        EXPECT_THAT(result[0].Values, Eq(Row{"Name", "Age", "City"}));
    }

    TEST_F(InteractorsTests, FirstPage_with_PageLength_3)
    {
        sut.Start({"persons.csv", "3"});
        sut.LastPage();

        auto result = sut.FirstPage();

        ASSERT_THAT(result, SizeIs(4));
        EXPECT_THAT(result[0].Values, Eq(Row{"Name", "Age", "City"}));
        EXPECT_THAT(result[1].Values, Eq(Row{"Peter","42","New York"}));
        EXPECT_THAT(result[3].Values, Eq(Row{ "Mary","35", "Frankfurt"}));
    }

    TEST_F(InteractorsTests, LastPage_with_PageLength_3)
    {
        sut.Start({"persons.csv", "3"});

        auto result = sut.LastPage();

        ASSERT_THAT(result, SizeIs(4));
        EXPECT_THAT(result[0].Values, Eq(Row{"Name", "Age", "City"}));
        EXPECT_THAT(result[1].Values, Eq(Row{"Heiner","42","Hamburg"}));
        EXPECT_THAT(result[3].Values, Eq(Row{ "Anna","27", "Berlin"}));
    }

    TEST_F(InteractorsTests, Start_with_optional_PageLength_parameter)
    {
        auto result = sut.Start({"persons.csv", "5"});

        ASSERT_THAT(result, SizeIs(6));
        EXPECT_THAT(result[0].Values, Eq(Row{"Name", "Age", "City"}));
        EXPECT_THAT(result[5].Values, Eq(Row{"Yuri", "23", "Moscow"}));
    }

    TEST_F(InteractorsTests, NextPage_with_PageLength_4)
    {
        sut.Start({"persons.csv", "4"});

        sut.NextPage();
        auto result = sut.NextPage();

        ASSERT_THAT(result, SizeIs(5));
        EXPECT_THAT(result[0].Values, Eq(Row{"Name", "Age", "City"}));
        EXPECT_THAT(result[1].Values, Eq(Row{"Stephan","13","Flensburg"}));
        EXPECT_THAT(result[4].Values, Eq(Row{ "Anna","27", "Berlin"}));
    }

    TEST_F(InteractorsTests, PrevPage_with_PageLength_4)
    {
        sut.Start({"persons.csv", "4"});
        sut.LastPage();

        auto result = sut.PrevPage();

        ASSERT_THAT(result, SizeIs(5));
        EXPECT_THAT(result[0].Values, Eq(Row{"Name", "Age", "City"}));
        EXPECT_THAT(result[1].Values, Eq(Row{"Yuri","23","Moscow"}));
        EXPECT_THAT(result[4].Values, Eq(Row{ "John","45", "Bochum"}));
    }
}