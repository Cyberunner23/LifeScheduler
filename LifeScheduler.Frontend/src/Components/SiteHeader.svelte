<header>

  <img alt="logo"/>


  <nav>
    <ul class="navLinks"> 
      <li> <a href="#"> Home </a> </li>
      <li> <a href="#"> Projects </a> </li>
      <li> <a href="#"> About </a> </li>
    </ul>
  </nav>

  <a href=#> <button> Contact </button> </a>
</header>

<style>

  header {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .navLinks {
    list-style: none;
  }

  .navLinks li {
    display: inline-block;
    padding: 0px 20px;
    
  }

  .navLinks li a {
    color: var(--primary);
    transition: all 0.3s ease 0s;
  }

  .navLinks li a:hover {
    background-color: var(--secondary);
  }

</style>