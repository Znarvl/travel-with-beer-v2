import {render, screen } from "@testing-library/react"
import Home from "@/app/page"

it("should have docs text", () => {
    render(<Home/>)
    const myElem = screen.getByText('Docs')
    expect(myElem).toBeInTheDocument()
})