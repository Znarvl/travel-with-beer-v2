import { prisma } from "@/db"


export default async function Home(){
  const users = await prisma.user.findMany()

  return (
    <div>
      <h1>Cool</h1>
    <ul>{users.map(user => (
      <li>{user.username}</li> ))}
      </ul>

    </div>


  )


}