package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.state.State;
import com.google.android.material.button.MaterialButton;

public class Select_tickets extends AppCompatActivity {
    private int adult_tickets=0;
    private int children_ticket=0;
    private int elder_ticket=0;
    private MaterialButton RChildren;
    private MaterialButton LChildren;
    private MaterialButton LAdult;
    private MaterialButton RAdult;
    private MaterialButton LElder;
    private MaterialButton RElder;
    private MaterialButton Buy;
    private TextView adultText;
    private TextView childrenText;
    private TextView elderText;
    private int max_tickets=10;
    private State state;
    private Db_helper DB;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_select_tickets);
        state=State.getInstance();
        max_tickets=state.getSeats().size();
        DB=new Db_helper(this);
        Buy=(MaterialButton)findViewById(R.id.select_tickets_button);
        Buy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                buy();
            }
        });
        RChildren=(MaterialButton)findViewById(R.id.children_right_button);
        RChildren.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RChildren();
            }
        });
        LChildren=(MaterialButton) findViewById(R.id.children_left_button);
        LChildren.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LChildren();
            }
        });
        RAdult=(MaterialButton) findViewById(R.id.adult_right_button);
        RAdult.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RAdult();
            }
        });
        LAdult=(MaterialButton)findViewById(R.id.adult_left_button);
        LAdult.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LAdult();
            }
        });
        RElder=(MaterialButton) findViewById(R.id.elder_right_button);
        RElder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                RElder();
            }
        });
        LElder=(MaterialButton) findViewById(R.id.elder_left_button);
        LElder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LElder();
            }
        });
        childrenText=(TextView)findViewById(R.id.children_number);
        adultText=(TextView)findViewById(R.id.adult_number);
        elderText=(TextView)findViewById(R.id.elder_number);
        updateLabel();



    }
    public void updateLabel(){
        childrenText.setText(Integer.toString(children_ticket));
        adultText.setText(Integer.toString(adult_tickets));
        elderText.setText(Integer.toString(elder_ticket));
    }

    public int LeftPressed(int tickets){
        if(tickets>=1){
            tickets-=1;
        }
        return tickets;
    }
    public int RightPressed(int tickets){
        if(!willOverFlow()){
            tickets+=1;
        }
        return tickets;
    }
    public void LChildren(){
        children_ticket=LeftPressed(children_ticket);
        updateLabel();
    }
    public void RChildren(){
        children_ticket=RightPressed(children_ticket);
        updateLabel();
    }
    public void LAdult(){
        adult_tickets=LeftPressed(adult_tickets);
        updateLabel();
    }
    public void RAdult(){
        adult_tickets=RightPressed(adult_tickets);
        updateLabel();
    }
    public void LElder(){
        elder_ticket=LeftPressed(elder_ticket);
        updateLabel();
    }
    public void RElder(){
        elder_ticket=RightPressed(elder_ticket);
        updateLabel();
    }


    public boolean willOverFlow(){
        int ticket_number=children_ticket+adult_tickets+elder_ticket+1;
        if(ticket_number>max_tickets){
            return true;
        }
        return false;
    }
    public void buy(){
        DB.Process_order(state.getUsername(),state.getProjection_id(),state.getSeats(),children_ticket,adult_tickets,elder_ticket);
        Toast toast=Toast.makeText(getApplicationContext(),"Compra Agregada",Toast.LENGTH_SHORT);
        toast.setMargin(400,400);
        toast.show();
    }
}