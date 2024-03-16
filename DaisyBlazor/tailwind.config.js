/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Components/**/*.{html,razor}"],
  theme: {
    extend: {},
  },
  plugins: [require("@tailwindcss/typography"), require("daisyui")],
}

