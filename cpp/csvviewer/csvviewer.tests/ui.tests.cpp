#include <gmock/gmock.h>
#include "Ui.h"

namespace csvviewer
{
    using namespace testing;
    TEST(UiTests, Formatting_very_simpel)
    {
        auto result = Ui::CreateLines({{{"a", "b", "c"}}, {{"1", "2", "3"}}});

        EXPECT_THAT(result, Eq(std::vector<std::string>{"a|b|c", "-+-+-", "1|2|3"}));
    }

    TEST(UiTests, Formatting_of_different_widths)
    {
        auto result = Ui::CreateLines({{{"a", "bb", "ccc"}}, {{"111", "22", "3"}}});

        EXPECT_THAT(result, Eq(std::vector<std::string>{"a  |bb|ccc", "---+--+---", "111|22|3  "}));
    }
}