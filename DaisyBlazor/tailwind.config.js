/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Components/**/*.{html,razor}", "./Styles/*.html"],
  theme: {
    extend: {},
  },
  plugins: [require("@tailwindcss/typography"), require("daisyui")],
}

